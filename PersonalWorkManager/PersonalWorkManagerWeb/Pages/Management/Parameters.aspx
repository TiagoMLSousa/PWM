﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Parameters.aspx.cs" Inherits="PersonalWorkManagerWeb.Pages.Management.Parameters" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="Parameters.js" />
        </Scripts>
    </asp:ScriptManagerProxy>
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">Parâmetros</h1>
        </div>
    </div>
    <div class="panel panel-default container-fluid">
        <div id="toolbar" class="btn-group btn-group-md">
            <button id="btnRefresh" type="button" class="btn btn-default" onclick="Parameters.getParameters();">
                <i class="glyphicon glyphicon-refresh"></i>&nbsp;Actualizar
            </button>
            <button id="btnAdd" type="button" class="btn btn-default" onclick="Parameters.showAddDialog();">
                <i class="glyphicon glyphicon-plus"></i>&nbsp;Novo
            </button>
            <button id="btnEdit" type="button" class="btn btn-default" onclick="Parameters.showEditDialog();">
                <i class="glyphicon glyphicon-edit"></i>&nbsp;Editar
            </button>
            <button id="btnRemove" type="button" class="btn btn-default" onclick="Parameters.showRemoveDialog();">
                <i class="glyphicon glyphicon-remove"></i>&nbsp;Remover
            </button>
        </div>
        <table id="tblParameters" 
               class="table table-striped table-bordered table-condensed"
               data-search="true"
               data-pagination="true"
               data-show-toggle="true"
               data-show-columns="true"
               data-sort-name="Id"
               data-sort-order="asc"
               data-toolbar="#toolbar"
               data-click-to-select="true">
            <thead>
            <tr>
                <th data-field="state" data-checkbox="true"></th>
                <th data-field="Id" data-sortable="true">Id</th>
                <th data-field="Name" data-sortable="true">Nome</th>
                <th data-field="Value" data-sortable="true">Valor</th>
                <th data-field="Description" data-sortable="true">Descrição</th>
                <th data-field="action" data-formatter="Parameters.actionFormatter" data-events="actionEvents">Acção</th>
            </tr>
            </thead>
        </table>
    </div>

    <!-- Modal -->
    <div class="modal fade" id="mdlParameter" tabindex="-1" role="dialog" aria-labelledby="mdlLabel"
        aria-hidden="true">
        <%--<div class="modal-dialog" style="width: 90%; margin-left:5%;">--%>
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="mdlLabel"></h4>
                </div>
                <div class="modal-body">
                    <div id="divModalMessage"></div>
                    <form>
                        <input type="hidden" id="txtId">
                        <div class="form-group">
                            <label class="control-label" for="txtName">Nome: </label>
                            <input type="text" class="form-control" id="txtName" placeholder="Nome">
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="txtValue">Valor: </label>
                            <input type="text" class="form-control" id="txtValue" placeholder="Valor">
                        </div>
                        <div class="form-group">
                            <label class="control-label" for="txtDescription">Descrição: </label>
                            <input type="text" class="form-control" id="txtDescription" placeholder="Descrição">
                        </div>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">
                        Cancelar</button>
                    <button id="btnActionConfirmed" type="button" class="btn btn-primary">
                        Guardar</button>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
