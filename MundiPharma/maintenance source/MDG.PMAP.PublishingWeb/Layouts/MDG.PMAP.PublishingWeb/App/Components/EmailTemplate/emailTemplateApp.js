var emailTemplateApp = angular.module('pmapApp');

emailTemplateApp.controller('emailTemplateController', ['pmapAjaxService', 'pmapModels', 'pmapHelpers', '$location', function (pmapAjaxService, pmapModels, pmapHelpers, $location) {
    var self = this;

    self.emailTemplate = [];
    self.data = {};

    self.loadEmailTemplate = function () {

        var _serviceUrl = window.webSiteUrl + '/_api/mdg/LoadEmailTemplate';
        pmapAjaxService.getRequest(_serviceUrl)
        .then(function (response) {
            self.holidays = JSON.parse(response.data.d.LoadEmailTemplate.Data);
        }, function (response) {
            window.pmapAjaxError = response;
            bootbox.alert({
                closeButton: false,
                title: "<span class='fa fa-info-circle'></span> Info <span class='fa fa-close fa-lg pull-right cursor-pointer' data-dismiss='modal' aria-hidden='true'></span>",
                message: "There was an error occured, please contact your IT administrator."
            });
        });
    };

    
    self.save = function (templateForm) {

        if (templateForm.$valid) {
            var _serviceUrl = window.webSiteUrl + '/_api/mdg/AddEmailTemplate';

            var _templateCopy = new pmapModels.EmailTemplate(self.data);


            _strData = { 'template': JSON.stringify(_templateCopy) };
            _formData = JSON.stringify(_strData);
            pmapAjaxService.postData(_formData, _serviceUrl);

        }
        return false;
    };

    self.delete = function (templateCode) {
        var _serviceUrl = window.webSiteUrl + '/_api/mdg/DeleteEmailTemplate(' + holidayId + ')';

        pmapAjaxService.getRequest(_serviceUrl)
        .then(function (response) {
            self.getHolidays();
        }, function (response) {
            window.pmapAjaxError = response;
            bootbox.alert({
                closeButton: false,
                title: "<span class='fa fa-info-circle'></span> Info <span class='fa fa-close fa-lg pull-right cursor-pointer' data-dismiss='modal' aria-hidden='true'></span>",
                message: "There was an error occured, please contact your IT administrator."
            });
        });


    }

    self.update = function () {

        var _serviceUrl = window.webSiteUrl + '/_api/mdg/UpdateEmailTemplate';

        var _templateCopy = new pmapModels.EmailTemplate(self.data);

        _strData = { 'template': JSON.stringify(_templateCopy) };
        _formData = JSON.stringify(_strData);
        pmapAjaxService.postData(_formData, _serviceUrl);

        return false;
    }

    self.loadEmailTemplate();

}]);
