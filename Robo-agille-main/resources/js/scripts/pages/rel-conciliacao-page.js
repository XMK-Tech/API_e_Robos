/**
 * DataTables Basic
 */

$(function () {
    'use strict';

    var dt_complex_header_table = $('.dt-complex-header')
    var idRelatorio = document.getElementById('idRelatorio').value;


    // Complex Header DataTable
    // --------------------------------------------------------------------

    if (dt_complex_header_table.length) {
        var dt_complex = dt_complex_header_table.DataTable({
            ajax: '/conciliacao/ajaxViewRelatorio/' + idRelatorio,
            columns: [

                { data: 'nome_vendedor' },
                { data: 'nome_erp_origem' },
                { data: 'nome_erp_destino' },
                { data: 'post' },
                { data: 'pedidov' },
                { data: 'codpedidov' },
                { data: 'nnf' },
                { data: 'total' },
                { data: 'repasse' },
                { data: 'data' },
                { data: 'filial' },

            ],
            columnDefs: [

                {
                    // Label
                    targets: -2,
                    render: function (data, type, full, meta) {
                        var $status_number = full['status'];
                        var $status = {
                            0: { title: 'Pendente', class: ' badge-light-warning' },
                            1: { title: 'Processado', class: 'badge-light-success' },
                            2: { title: 'Professional', class: ' badge-light-success' },
                            3: { title: 'Rejected', class: ' badge-light-danger' },
                            4: { title: 'Resigned', class: ' badge-light-warning' },
                            5: { title: 'Applied', class: ' badge-light-info' }
                        };
                        if (typeof $status[$status_number] === 'undefined') {
                            return data;
                        }
                        return (
                            '<span class="badge rounded-pill ' +
                            $status[$status_number].class +
                            '">' +
                            $status[$status_number].title +
                            '</span>'
                        );
                    }
                },

                {
                    // Actions
                    targets: -1,
                    // title: 'FILIAL',
                    orderable: true,
                    // render: function (data, type, full, meta) {
                    //     return (
                    //         '<div class="d-inline-flex">' +
                    //         '<a class="pe-1 dropdown-toggle hide-arrow text-primary" data-bs-toggle="dropdown">' +
                    //         feather.icons['more-vertical'].toSvg({ class: 'font-small-4' }) +
                    //         '</a>' +
                    //         '<div class="dropdown-menu dropdown-menu-end">' +
                    //         '<a href="javascript:;" class="dropdown-item">' +
                    //         feather.icons['file-text'].toSvg({ class: 'me-50 font-small-4' }) +
                    //         'Details</a>' +
                    //         '<a href="javascript:;" class="dropdown-item">' +
                    //         feather.icons['archive'].toSvg({ class: 'me-50 font-small-4' }) +
                    //         'Archive</a>' +
                    //         '<a href="javascript:;" class="dropdown-item delete-record">' +
                    //         feather.icons['trash-2'].toSvg({ class: 'me-50 font-small-4' }) +
                    //         'Delete</a>' +
                    //         '</div>' +
                    //         '</div>' +
                    //         '<a href="javascript:;" class="item-edit">' +
                    //         feather.icons['edit'].toSvg({ class: 'font-small-4' }) +
                    //         '</a>'
                    //     );
                    // }
                }
            ],
            dom: '<"card-header border-bottom p-1"<"head-label"><"dt-action-buttons text-end"B>><"d-flex justify-content-between align-items-center mx-0 row"<"col-sm-12 col-md-6"l><"col-sm-12 col-md-6"f>>t<"d-flex justify-content-between mx-0 row"<"col-sm-12 col-md-6"i><"col-sm-12 col-md-6"p>>',
            displayLength: 25,
            lengthMenu: [10, 25, 50, 75, 100],
            buttons: [
                {
                    extend: 'collection',
                    className: 'btn btn-outline-secondary dropdown-toggle me-2',
                    text: feather.icons['share'].toSvg({ class: 'font-small-4 me-50' }) + 'Exportar',
                    buttons: [
                        {
                            extend: 'print',
                            text: feather.icons['printer'].toSvg({ class: 'font-small-4 me-50' }) + 'Print',
                            className: 'dropdown-item',
                            exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] }
                        },
                        {
                            extend: 'csv',
                            text: feather.icons['file-text'].toSvg({ class: 'font-small-4 me-50' }) + 'Csv',
                            className: 'dropdown-item',
                            exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] }
                        },
                        {
                            extend: 'excel',
                            text: feather.icons['file'].toSvg({ class: 'font-small-4 me-50' }) + 'Excel',
                            className: 'dropdown-item',
                            exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] }
                        },
                        {
                            extend: 'pdf',
                            text: feather.icons['clipboard'].toSvg({ class: 'font-small-4 me-50' }) + 'Pdf',
                            className: 'dropdown-item',
                            exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] }
                        },
                        {
                            extend: 'copy',
                            text: feather.icons['copy'].toSvg({ class: 'font-small-4 me-50' }) + 'Copy',
                            className: 'dropdown-item',
                            exportOptions: { columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10] }
                        }
                    ],
                    init: function (api, node, config) {
                        $(node).removeClass('btn-secondary');
                        $(node).parent().removeClass('btn-group');
                        setTimeout(function () {
                            $(node).closest('.dt-buttons').removeClass('btn-group').addClass('d-inline-flex');
                        }, 50);
                    }
                },
            ],
            responsive: {
                details: {
                    display: $.fn.dataTable.Responsive.display.modal({
                        header: function (row) {
                            var data = row.data();
                            return 'Details of ' + data['full_name'];
                        }
                    }),
                    type: 'column',
                    renderer: function (api, rowIdx, columns) {
                        var data = $.map(columns, function (col, i) {
                            return col.title !== '' // ? Do not show row in modal popup if title is blank (for check box)
                                ? '<tr data-dt-row="' +
                                col.rowIdx +
                                '" data-dt-column="' +
                                col.columnIndex +
                                '">' +
                                '<td>' +
                                col.title +
                                ':' +
                                '</td> ' +
                                '<td>' +
                                col.data +
                                '</td>' +
                                '</tr>'
                                : '';
                        }).join('');

                        return data ? $('<table class="table"/>').append('<tbody>' + data + '</tbody>') : false;
                    }
                }
            },
            language: {
                paginate: {
                    // remove previous & next text from pagination
                    previous: '&nbsp;',
                    next: '&nbsp;'
                }
            }
        });
        var rangeData = document.getElementById('rangedata').value;
        $('div.head-label').html('<h6 class="mb-0">' + rangeData + '</h6>');
    }



});
