var businessHolidaysApp = angular.module('pmapApp');

businessHolidaysApp.controller('businessHolidaysController', ['pmapAjaxService', 'pmapModels', 'pmapHelpers', '$location', function (pmapAjaxService, pmapModels, pmapHelpers, $location) {
    var self = this;

    self.holidays = [];
    self.data = {};

    self.getHolidays = function () {

        var _serviceUrl = window.webSiteUrl + '/_api/mdg/LoadBusinessHolidays';
        pmapAjaxService.getRequest(_serviceUrl)
        .then(function (response) {
            self.holidays = JSON.parse(response.data.d.LoadBusinessHolidays.Data);
        }, function (response) {
            window.pmapAjaxError = response;
            bootbox.alert({
                closeButton: false,
                title: "<span class='fa fa-info-circle'></span> Info <span class='fa fa-close fa-lg pull-right cursor-pointer' data-dismiss='modal' aria-hidden='true'></span>",
                message: "There was an error occured, please contact your IT administrator."
            });
        });
    };

    self.dateFormat = function (dateValue, format) {
        format = format || 'MM/DD/YYYY';
        return moment(dateValue).format(format);
    };

    self.save = function (holidayForm) {

        if (holidayForm.$valid) {
            var _serviceUrl = window.webSiteUrl + '/_api/mdg/AddBusinessHoliday';

            var _holidayCopy = new pmapModels.BusinessHoliday(self.data);

            _holidayCopy.HolidayDate = moment(_holidayCopy.HolidayDate).toDate().toMSJSON();


            _strData = { 'day': JSON.stringify(_holidayCopy) };
            _formData = JSON.stringify(_strData);
            pmapAjaxService.postData(_formData, _serviceUrl);

        }
        return false;
    };

    self.delete = function (holidayId) {
        var _serviceUrl = window.webSiteUrl + '/_api/mdg/DeleteBusinessHoliday(' + holidayId + ')';

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

        var _serviceUrl = window.webSiteUrl + '/_api/mdg/UpdateBusinessHoliday';

        var _holidayCopy = new pmapModels.BusinessHoliday(self.data);

        _holidayCopy.HolidayDate = moment(_holidayCopy.HolidayDate).toDate().toMSJSON();


        _strData = { 'day': JSON.stringify(_holidayCopy) };
        _formData = JSON.stringify(_strData);
        pmapAjaxService.postData(_formData, _serviceUrl);

        //self.getHolidays();

        return false;
    }

    self.view = function (id, day) {


        if (id != null && day != null) {
            self.data.Id = id;
            self.data.HolidayDate = new Date(day);

        }

        return false;
    }

    self.getHolidays();

    self.view();

}]);
