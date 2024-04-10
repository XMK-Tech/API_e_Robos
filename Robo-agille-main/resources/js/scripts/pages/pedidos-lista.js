/*=========================================================================================
    File Name: app-invoice-list.js
    Description: app-invoice-list Javascripts
    ----------------------------------------------------------------------------------------
    Item Name: Vuexy  - Vuejs, HTML & Laravel Admin Dashboard Template
   Version: 1.0
    Author: PIXINVENT
    Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/

$(function () {
    'use strict';
    var dtInvoiceTable = $('.invoice-list-table'),


        assetPath = '../../../app-assets/',
        invoicePreview = 'app-invoice-preview.html',
        pedidoAdd = '/captura/triangular',
        invoiceEdit = 'app-invoice-edit.html';

    if ($('body').attr('data-framework') === 'laravel') {
        assetPath = $('body').attr('data-asset-path');
        invoicePreview = assetPath + 'app/invoice/preview';
        pedidoAdd = '/captura/triangular';
        invoiceEdit = assetPath + 'app/invoice/edit';
    }

    // datatable
    if (dtInvoiceTable.length) {
        var dtInvoice = dtInvoiceTable.DataTable({
            ajax: "/bMf86biXO3b17ic17ms2s4ct42Tt", // JSON file to add data
            autoWidth: true,
            columns: [
                // columns according to JSON
                { data: 'responsive_id' },
                { data: 'invoice_id' },
                { data: 'invoice_status' },
                { data: 'client_name' },
                { data: 'total' },
                { data: 'balance' },
                { data: 'issued_date' },
                { data: 'pedido_status' },
                { data: '' }
            ],
            columnDefs: [
                {
                    // For Responsive
                    className: 'control',
                    responsivePriority: 2,
                    targets: 0
                },
                {
                    // Invoice ID
                    targets: 1,
                    width: '46px',
                    render: function (data, type, full, meta) {
                        var $invoiceId = full['invoice_id'];
                        // Creates full output for row
                        var $rowOutput = '<a class="fw-bold" href="' + invoicePreview + '"> #' + $invoiceId + '</a>';
                        return $rowOutput;
                    }
                },
                {
                    // Invoice status
                    targets: 2,
                    width: '42px',
                    render: function (data, type, full, meta) {
                        var $invoiceStatus = full['pedido_status'],
                            $filial = full['filial'],
                            $triangular = full['tipo_pedido'],
                            $capturada = full['capturada'],
                            $nf = full['nNf'],
                            $conta = full['conta'],
                            $balance = full['balance'],
                            roleObj = {
                                Pendente: { class: 'bg-light-warning', icon: 'triangle' },
                                Manual: { class: 'bg-light-warning', icon: 'triangle' },
                                Capturada: { class: 'bg-light-success', icon: 'triangle' },
                                Cancelado: { class: 'bg-light-danger', icon: 'triangle' },
                                NormalCancelado: { class: 'bg-light-danger', icon: 'alert-circle' },
                                Normal: { class: 'bg-light-info', icon: 'check-circle' },
                                Downloaded: { class: 'bg-light-primary', icon: 'arrow-down-circle' },
                                'Past Due': { class: 'bg-light-danger', icon: 'info' },
                                'Partial Payment': { class: 'bg-light-warning', icon: 'pie-chart' }
                            };

                        switch ($capturada) {
                            case 'Capturada':
                                return (
                                    "<span data-bs-toggle='tooltip' data-bs-html='true' title='<span>" +
                                    $invoiceStatus +
                                    '<br> <span class="fw-bold">Valor:</span> ' +
                                    $balance +
                                    '<br> <span class="fw-bold">Conta:</span> ' +
                                    $conta +
                                    '<br> <span class="fw-bold">nº NF:</span> ' +
                                    $nf +
                                    '<br> <span class="fw-bold">Filial:</span> ' +
                                    $filial +
                                    "</span>'>" +
                                    '<div class="avatar avatar-status ' +
                                    roleObj[$invoiceStatus].class +
                                    '">' +
                                    '<span class="avatar-content">' +
                                    feather.icons[roleObj[$invoiceStatus].icon].toSvg({ class: 'avatar-icon' }) +
                                    '</span>' +
                                    '</div>' +
                                    '</span>'
                                );
                                break;
                            case 'Pendente':
                                return (
                                    "<span data-bs-toggle='tooltip' data-bs-html='true' title='<span>" + $invoiceStatus + "</span>'>" +
                                    '<div class="avatar avatar-status ' +
                                    roleObj[$invoiceStatus].class +
                                    '">' +
                                    '<span class="avatar-content">' + feather.icons[roleObj[$invoiceStatus].icon].toSvg({ class: 'avatar-icon' }) + '</span>' +
                                    '</div>' +
                                    '</span>'
                                );
                                break;
                            case 'Manual':
                                return (
                                    "<span data-bs-toggle='tooltip' data-bs-html='true' title='<span>" + $invoiceStatus + "</span>'>" +
                                    '<div class="avatar avatar-status ' +
                                    roleObj[$invoiceStatus].class +
                                    '">' +
                                    '<span class="avatar-content">' + feather.icons[roleObj[$invoiceStatus].icon].toSvg({ class: 'avatar-icon' }) + '</span>' +
                                    '</div>' +
                                    '</span>'
                                );
                                break;
                            case 'Cancelado':
                                return (
                                    "<span data-bs-toggle='tooltip' data-bs-html='true' title='<span>" + $invoiceStatus + "</span>'>" +
                                    '<div class="avatar avatar-status ' +
                                    roleObj[$invoiceStatus].class +
                                    '">' +
                                    '<span class="avatar-content">' + feather.icons[roleObj[$invoiceStatus].icon].toSvg({ class: 'avatar-icon' }) + '</span>' +
                                    '</div>' +
                                    '</span>'
                                );
                                break;
                            case 'Normal':
                                return (
                                    "<span data-bs-toggle='tooltip' data-bs-html='true' title='<span>" + $invoiceStatus + "</span>'>" +
                                    '<div class="avatar avatar-status ' + roleObj[$invoiceStatus].class + '">' +
                                    '<span class="avatar-content">' + feather.icons[roleObj[$invoiceStatus].icon].toSvg({ class: 'avatar-icon' }) +
                                    '</div>' +
                                    '</span>'
                                );
                                break;
                            case 'NormalCancelado':
                                return (
                                    "<span data-bs-toggle='tooltip' data-bs-html='true' title='<span>" + $invoiceStatus + "</span>'>" +
                                    '<div class="avatar avatar-status ' + roleObj[$invoiceStatus].class + '">' +
                                    '<span class="avatar-content">' + feather.icons[roleObj[$invoiceStatus].icon].toSvg({ class: 'avatar-icon' }) +
                                    '</div>' +
                                    '</span>'
                                );
                                break;
                            default:
                                return (
                                    "<span data-bs-toggle='tooltip' data-bs-html='true' title='<span>Falha!</span>'>" +
                                    '<div class="avatar avatar-status bg-light-danger">' +
                                    '<span class="avatar-content"><i data-feather="alert-octagon"></i>' +
                                    '</div>' +
                                    '</span>'
                                );

                        }

                    },
                },
                {
                    // Client name and Service
                    targets: 3,
                    responsivePriority: 4,
                    width: '270px',
                    render: function (data, type, full, meta) {
                        var $name = full['client_name'],
                            $vendedor = full['vendedor'],
                            $image = full['avatar'],
                            stateNum = Math.floor(Math.random() * 6),
                            states = ['success', 'danger', 'warning', 'info', 'primary', 'secondary'],
                            $state = states[stateNum],
                            $name = full['client_name'],
                            $initials = $name.match(/\b\w/g) || [];
                        $initials = (($initials.shift() || '') + ($initials.pop() || '')).toUpperCase();
                        if ($image) {
                            // For Avatar image
                            var $output =
                                '<img  src="' + assetPath + 'images/avatars/' + $image + '" alt="Avatar" width="32" height="32">';
                        } else {
                            // For Avatar badge
                            $output = '<div class="avatar-content">' + $initials + '</div>';
                        }
                        // Creates full output for row
                        var colorClass = $image === '' ? ' bg-light-' + $state + ' ' : ' ';

                        var $rowOutput =
                            '<div class="d-flex justify-content-left align-items-center">' +
                            '<div class="avatar-wrapper">' +
                            '<div class="avatar' +
                            colorClass +
                            'me-50">' +
                            $output +
                            '</div>' +
                            '</div>' +
                            '<div class="d-flex flex-column">' +
                            '<h6 class="user-name text-truncate mb-0">' +
                            $name +
                            '</h6>' +
                            '<small class="text-truncate text-muted">Vendedor: ' +
                            $vendedor +
                            '</small>' +
                            '</div>' +
                            '</div>';
                        return $rowOutput;
                    }
                },

                {
                    // Total Invoice Amount
                    targets: 4,
                    width: '73px',
                    render: function (data, type, full, meta) {
                        var $total = full['total'];
                        return '<span class="d-none">' + $total + '</span>' + $total;
                    }
                },

                {
                    // Client Balance/Status
                    targets: 5,
                    width: '98px',
                    render: function (data, type, full, meta) {
                        var $balance = full['valor_final'];
                        if ($balance === 0) {
                            var $badge_class = 'badge-light-success';
                            return '<span class="badge rounded-pill ' + $badge_class + '" text-capitalized> s/ desconto </span>';
                        } else {
                            return '<span class="d-none">' + $balance + '</span>' + $balance;
                        }
                    }
                },
                {
                    // Due Date
                    targets: 6,
                    width: '130px',
                    render: function (data, type, full, meta) {
                        var $total = full['due_date'];
                        return '<span class="d-none">' + $total + '</span>' + $total;
                    }
                },
                {
                    targets: 7,
                    width: '130px',
                    visible: true,
                    render: function (data, type, full, meta) {
                        var $date = full['issued_date'];
                        var $output = '<span class="d-none">' + $date + '</span>' + $date;
                        return $output;
                    }
                },
                {
                    // Actions
                    targets: -1,
                    title: 'OPÇÕES',
                    width: '80px',
                    orderable: false,
                    render: function (data, type, full, meta) {
                        var $invoiceId = full['invoice_id'];
                        var $capturada = full['capturada'];
                        var $listaErp = full['listaErps'];
                        if ($capturada == 'Manual') {
                            return (
                                '<div class="d-flex align-items-center col-actions">' +
                                '<div class="dropdown">' +
                                '<a title="Capturar" class="btn btn-sm btn-icon dropdown-toggle hide-arrow" data-bs-toggle="dropdown">' +
                                feather.icons['send'].toSvg({ class: 'font-medium-2 text-body' }) +
                                '</a>' +
                                '<div class="dropdown-menu dropdown-menu-end">' +
                                $listaErp +
                                '</div>' +
                                '</div>' +
                                '</div>' +
                                '</div>'
                            );
                        } else {
                            return (
                                '<div class="d-flex align-items-center col-actions">' +
                                '<div class="col-actions">' +
                                '<div class="dropdown">' +
                                '<a class="btn btn-sm btn-icon dropdown-toggle hide-arrow" data-bs-toggle="dropdown">' +
                                feather.icons['more-vertical'].toSvg({ class: 'font-medium-2 text-body' }) +
                                '</a>' +
                                '<div class="dropdown-menu dropdown-menu-end">' +
                                '<a href="#" class="dropdown-item">' +
                                feather.icons['download'].toSvg({ class: 'font-small-4 me-50' }) +
                                'Download</a>' +
                                '<a href="' +
                                invoiceEdit +
                                '" class="dropdown-item">' +
                                feather.icons['edit'].toSvg({ class: 'font-small-4 me-50' }) +
                                'Edit</a>' +
                                '<a href="#" class="dropdown-item">' +
                                feather.icons['trash'].toSvg({ class: 'font-small-4 me-50' }) +
                                'Delete</a>' +
                                '<a href="#" class="dropdown-item">' +
                                feather.icons['copy'].toSvg({ class: 'font-small-4 me-50' }) +
                                'Duplicate</a>' +
                                '</div>' +
                                '</div>' +
                                '</div>' +
                                '</div>'
                            );

                        }
                    }
                }
            ],
            order: [[1, 'desc']],
            dom:
                '<"row d-flex justify-content-between align-items-center m-1"' +
                '<"col-lg-6 d-flex align-items-center"l<"dt-action-buttons text-xl-end text-lg-start text-lg-end text-start "B>>' +
                '<"col-lg-6 d-flex align-items-center justify-content-lg-end flex-lg-nowrap flex-wrap pe-lg-1 p-0"f<"invoice_status ms-sm-2">>' +
                '>t' +
                '<"d-flex justify-content-between mx-2 row"' +
                '<"col-sm-12 col-md-6"i>' +
                '<"col-sm-12 col-md-6"p>' +
                '>',
            language: {
                sLengthMenu: 'Show _MENU_',
                search: 'Busca',
                searchPlaceholder: '',
                paginate: {
                    // remove previous & next text from pagination
                    previous: '&nbsp;',
                    next: '&nbsp;'
                }
            },
            // Buttons with Dropdown
            buttons: [
                {
                    text: 'Capturar',
                    className: 'btn btn-primary btn-add-record ms-2 d-none',
                    action: function (e, dt, button, config) {
                        window.location = pedidoAdd;
                    }
                }
            ],
            // For responsive popup
            responsive: {
                details: {
                    display: $.fn.dataTable.Responsive.display.modal({
                        header: function (row) {
                            var data = row.data();
                            return 'Details of ' + data['client_name'];
                        }
                    }),
                    type: 'column',
                    renderer: function (api, rowIdx, columns) {
                        var data = $.map(columns, function (col, i) {
                            return col.columnIndex !== 2 // ? Do not show row in modal popup if title is blank (for check box)
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
            initComplete: function () {
                $(document).find('[data-bs-toggle="tooltip"]').tooltip();
                // Adding role filter once table initialized
                this.api()
                    .columns(7)
                    .every(function () {
                        var column = this;
                        var select = $(
                            '<select id="UserRole" class="form-select ms-50 text-capitalize"><option value=""> Status </option></select>'
                        )
                            .appendTo('.invoice_status')
                            .on('change', function () {
                                var val = $.fn.dataTable.util.escapeRegex($(this).val());
                                column.search(val ? '^' + val + '$' : '', true, false).draw();
                            });

                        column
                            .data()
                            .unique()
                            .sort()
                            .each(function (d, j) {
                                select.append('<option value="' + d + '" class="text-capitalize">' + d + '</option>');
                            });
                    });
            },
            drawCallback: function () {
                $(document).find('[data-bs-toggle="tooltip"]').tooltip();
            }
        });
    }
});
