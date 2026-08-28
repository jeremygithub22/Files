<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=16.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="MDG" Namespace="MDG.PMAP.Common.Control" Assembly="MDG.PMAP.Common, Version=1.0.0.0, Culture=neutral, PublicKeyToken=5ec3e8353ce07137" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmailTemplateWebPart.ascx.cs" Inherits="MDG.PMAP.PublishingWebParts.EmailTemplateWebPart.EmailTemplateWebPart" %>

<MDG:Link ID="productsJS" runat="server" Location="Hive" ScriptType="Script" Href="/_layouts/MDG.PMAP.PublishingWeb/App/Components/EmailTemplate/emailTemplateApp.js" />

<script type="text/javascript">
    var webSiteURL = "<%= SPContext.Current.Web.Url %>";
</script>

<div class="pmap-panel" ng-app="pmapApp">
    <div class="panel" ng-controller="emailTemplateController as ctrl">
        <div class="panel-heading">
            <h1 class="panel-title">Email Template</h1>
        </div>
        <div class="bs-component panel-body">
            <input type="button" class="btn primary-button panel-create-btn"  data-toggle="modal" data-target="#productDetailModal" value="Create New" />
            <div class="form-inline">
                <div class="input-group input-group-sm pull-right raf-search">
                    <span class="input-group-addon"><i class="fa fa-search"></i></span>
                    <input class="form-control" placeholder="Search here..." type="text" ng-model="ctrl.filters.emailTemplate">
                </div>
            </div>
            <div style="clear: both;">
                <br />
            </div>
            <div class="tab-container">
                <div class="tab-content">
                    <div class="tab-pane active">
                        <div class="col-md-12 raf-inprogress-table">
                            <div class="table-responsive">
                                <table class="raf-main-details-table table table-hover text-center">
                                    <thead>
                                        <tr>
                                            <th>TEMPLATE CODE</th>
                                            <th>SUBJECT</th>
                                            <th>BODY</th>
                                        </tr>
                                    </thead>
                                    <tbody dir-paginate="template in ctrl.emailTemplate|filter: ctrl.emailTemplateFilter|itemsPerPage:10">
                                        <tr>
                                            <td>{{template.TemplateCode}}</td>
                                            <td>{{template.Subject}}</td>
                                            <td>{{template.Body}}</td>
                                            <td>
                                                <a href="#" class="btn btn-default btn-xs" title="Post Activity" ng-click="ctrl.loadProduct('' + product.Id + '', productForm)" data-toggle="modal" data-target="#productDetailModal">
                                                    <i class="fa fa-pencil-square-o"></i>
                                                </a>
                                                <a href="#" ng-click="ctrl.delete(product.Id)" class="btn btn-default btn-xs" title="Delete">
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
                    <div class="clearfix"></div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="emailTemplateModal" role="dialog" style="display: none;">
            <div class="modal-dialog modal-lg" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <span class="fa fa-close fa-lg pull-right" data-dismiss="modal" aria-hidden="true"></span>
                        <h4 class="modal-title">Email Template</h4>
                    </div>
                    <div class="modal-body">
                        <div ng-form="productForm">
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <div class="col-sm-3">
                                            <label>Template Code: <span class="color-red">*</span></label>
                                        </div>
                                        <div class="col-sm-9">
                                            <span class="pull-right warning-text" ng-show="ctrl.toggles.nameLimit">{{100 - ctrl.data.Name.length}} characters remaining</span>
                                            <input type="text" name="Name" class="form-control" ng-model="ctrl.data.Name" required ng-required="true" maxlength="100"
                                                ng-focus="ctrl.toggles.nameLimit = true" ng-blur="ctrl.toggles.nameLimit = false"/>
                                            <span class="error-message" ng-show="productForm.Name.$touched && productForm.Name.$invalid">This field is required or has invalid data.</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <div class="col-sm-3">
                                            <label>Subject: <span class="color-red">*</span></label>
                                        </div>
                                        <div class="col-sm-9">
                                            <span class="pull-right warning-text" ng-show="ctrl.toggles.codeLimit">{{50 - ctrl.data.Code.length}} characters remaining</span>
                                            <input type="text" name="Code" class="form-control" ng-model="ctrl.data.Code" required ng-required="true" maxlength="50"
                                                ng-focus="ctrl.toggles.codeLimit = true" ng-blur="ctrl.toggles.codeLimit = false"/>
                                            <span class="error-message" ng-show="productForm.Code.$touched && productForm.Code.$invalid">This field is required or has invalid data.</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="form-group">
                                        <div class="col-sm-3">
                                            <label>Email Body: <span class="color-red">*</span></label>
                                        </div>
                                        <div class="col-sm-9">
                                            <span class="pull-right warning-text" ng-show="ctrl.toggles.codeToGenerateLimit">{{50 - ctrl.data.CodeToGenerate.length}} characters remaining</span>
                                            <input type="text" name="CodeToGenerate" class="form-control" ng-model="ctrl.data.CodeToGenerate" maxlength="50"
                                                ng-focus="ctrl.toggles.codeToGenerateLimit = true" ng-blur="ctrl.toggles.codeToGenerateLimit = false"/>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn primary-button" data-dismiss="modal" ng-click="ctrl.save(productForm)" ng-disabled="!ctrl.isFormValid()">Submit</button>
                        <button type="button" class="btn btn-danger" data-dismiss="modal">Close</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>