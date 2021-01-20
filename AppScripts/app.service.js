window.app = window.todoApp || {};

window.app.service = (function () {
    var baseUri = '/api/Subscriptions';
    var typesUri = '/api/Subscriptions/Types';
    var serviceUrls = {
        subscriptions: function () { return baseUri; },
        ByType: function (subscriptionType) { return baseUri + '?type=' + subscriptionType; },
        byId: function (id) { return baseUri + '/' + id; },
        subscriptionTypes: function () { return typesUri;}
    }

    function ajaxRequest(type, url, data) {
        var options = {
            url: url,
            headers: {
                Accept: "application/json"
            },
            contentType: "application/json",
            cache: false,
            type: type,
            data: data ? ko.toJSON(data) : null
        };
        return $.ajax(options);
    }

    return {
        allSubscriptions: function () {
            return ajaxRequest('get', serviceUrls.subscriptions());
        },
        ByType: function (subscriptionType) {
            return ajaxRequest('get', serviceUrls.ByType(subscriptionType));
        },
        update: function (item) {
            return ajaxRequest('put', serviceUrls.byId(item.ID), item);
        },
        allSubscriptionTypes: function () {
            return ajaxRequest('get', serviceUrls.subscriptionTypes());
        }
    };
})();
