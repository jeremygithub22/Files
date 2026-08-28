<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BusinessHolidaysWebPart.ascx.cs" Inherits="MDG.PMAP.PublishingWebParts.BusinessHolidaysWebPart.BusinessHolidaysWebPart" %>

<%@Register TagPrefix="MDG" Namespace="MDG.PMAP.Common.Control" Assembly="MDG.PMAP.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=5ec3e8353ce07137"%>
<MDG:Link ID="businessHolidaysApp" runat="server" Location="Hive" ScriptType="Script" Href="/_layouts/MDG.PMAP.PublishingWeb/App/Components/BusinessHolidays/BusinessHolidaysApp.js" />

<script>
    window.webSiteURL = "<%= SPContext.Current.Site.Url %>";
    MdgCommon.hideLoader();
</script>

<div class="pmap-panel" ng-app="pmapApp">
    <div class="panel" ng-controller="businessHolidaysController as ctrl">
        <div class="panel-heading">
            <h1 class="panel-title">Business Holidays</h1>
        </div>
        <div class="bs-component panel-body" ng-form="holidayForm">
            <div class="row">
                <div class="col-sm-6">
                    <div class="form-group">
                        <div class="col-sm-2">
                            <!--button type="button" ng-click="ctrl.save(holidayForm)">Add</button--> 
                            <button type="button" data-toggle="modal" data-target="#businessHolidayDetailModal">Add</button>
                        </div>
                        <div class="col-sm-2">
                                <button type="button" ng-click="ctrl.update()">Update</button> 
                        </div>
                        <div class="col-sm-3">
                                <button type="button" ng-click="ctrl.delete(ctrl.data.Id)">Delete</button> 
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">

            </div>
            <div class="row">
                <div class="tab-content">
                    <div class="tab-pane active">
                        <div class="col-md-12 table-responsive">
                            <table id  ="ListData" class="table table-hover text-center">
                                    <thead>
                                        <tr>
                                            <th>Business Holiday Id
								                <span class="glyphicon sort-icon"></span>
                                            </th>
                                            <th>Holiday Date
								                <span class="glyphicon sort-icon"></span>
                                            </th>
                                            <th style="min-width: 130px;">ACTION</th>                     
                                        </tr>
                                </thead>
                                <tbody dir-paginate="holiday in ctrl.holidays|itemsPerPage:10">
                                    <tr ng-class="{active : ctrl.data.Id === holiday.Id}">
                                        <td ng-click="ctrl.view(holiday.Id,holiday.HolidayDate);">{{holiday.Id}}</td>
                                        <td ng-click="ctrl.view(holiday.Id,holiday.HolidayDate);">{{ctrl.dateFormat(holiday.HolidayDate,"MM/DD/YYYY")}}</td>
                                        <td>
                                                <a href="#" class="btn btn-default btn-xs" title="Post Activity" ng-click="alert('test')" data-toggle="modal" data-target="#productDetailModal">
                                                    <i class="fa fa-pencil-square-o"></i>
                                                </a>
                                                <a href="#" ng-click="alert('test')" class="btn btn-default btn-xs" title="Delete">
                                                    <i class="fa fa-trash"></i>
                                                </a>
                                        </td>
                                    </tr>
                                </tbody>

                         </table>
                    </div>
                        <dir-pagination-controls
                                max-size="5"
                                direction-links="true"
                                boundary-links="true" class="pull-right">
				                </dir-pagination-controls>
                </div>
             </div>
           </div>
        </div>
        <div class="modal fade" id="businessHolidayDetailModal" role="dialog" style="display: none;">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <span class="fa fa-close fa-lg pull-right" data-dismiss="modal" aria-hidden="true"></span>
                        <h4 class="modal-title">Holiday Date</h4>
                    </div>
                    <div class="modal-body">
                        <div ng-form="userForm">
                            <div class="row">
                                <div class="col-sm-12">
                                    <div class="form-group">
                                        <div class="col-sm-3">
                                            <label>Holiday Date: *</label>
                                        </div>
                                        <div class="col-sm-9">
                                            <input type="text" name="dtHolidayDate" class="form-control disabled-text" date-time required  ng-model="ctrl.data.HolidayDate" min-view="date" auto-close="true" view="date" maxlength="10" format="MM/DD/YYYY"/> 
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn primary-button" data-dismiss="modal">Close</button>
                        <button type="button" class="btn primary-button pull-right" data-dismiss="modal" ng-click="ctrl.save(userForm)">Submit</button>
                    </div>
                </div>
            </div>
        </div>
    
    </div>
</div>