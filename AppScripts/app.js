(function () {
    ko.observable.fn.store = function () {
        return this;
    }

    function subscription(data) {
        var self = this;
        data = data || {};

        self.ID = data.Id;
        self.Name = ko.observable(data.Name).store();
        self.Description = ko.observable(data.Description).store();
        self.SubscriptionType = ko.observable(data.SubscriptionType).store();
        self.Price = ko.observable(data.Price).store();
        self.SubscriptionDurationString = ko.observable(data.SubscriptionDurationString).store();

    };

    function createSubscriptionType(data) {
        data = data || {};

        this.ID = data.Id;
        this.Name = ko.observable(data.Name);
        this.Description = ko.observable(data.Description);
        this.ImageSource = ko.observable(data.ImageSource);

    };
    
    var ViewModel = function () {
        var self = this;

        //Get Subscription Types for card views
        self.types = ko.observableArray();
        app.service.allSubscriptionTypes().then(addSubscriptionTypes, onError);
        function addSubscriptionTypes(data) {
            var mapped = ko.utils.arrayMap(data, function (item) {
                return new createSubscriptionType(item);
            });
            self.types(mapped);
        }

        self.subscriptions = ko.observableArray();
        self.error = ko.observable();
        self.subscriptionType = ko.observable();  
        self.checkoutSubscriptions = ko.observableArray();

        function addSubscriptions(data) {
            var mapped = ko.utils.arrayMap(data, function (item) {
                return new subscription(item);
            });
            self.subscriptions(mapped);
        }

        function onError(error) {
            self.error('Error: ' + error.status + ' ' + error.statusText);
        }

        self.checkout = function (subscription) {
            self.checkoutSubscriptions.push(subscription);
        };

        //Get subscriptions per subscription type
        self.getBySubscriptionType = function (subscriptionType) {
            self.error('');
            var type = subscriptionType.Name();
            self.subscriptionType(type);
            app.service.ByType(type).then(addSubscriptions, onError);
        };

    }

    ko.applyBindings(new ViewModel());
})();
