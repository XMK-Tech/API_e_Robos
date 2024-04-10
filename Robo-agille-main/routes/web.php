<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\AuthenticationController;
use App\Http\Controllers\DashboardController;
use App\Http\Controllers\FileController;
use App\Http\Controllers\ImovelController;
use App\Http\Controllers\DitrController;
use App\Http\Controllers\PDFImportController;



/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

$appName = 'App\Http\Controllers';
// Main Page Route
Route::get('/', [AuthenticationController::class, 'index'])->name('login');
Route::get('home', [DashboardController::class, 'home'])->name('dashboard-home');

/* Route Dashboards */

/* converters/rota */
Route::group(['prefix' => 'converters'], function () {
    Route::get('imoveis/imoveis-file-uploader', [FileController::class, 'imoveis_file_uploader'])->name('imoveis-file-uploader');
    Route::get('ditr/ditr-file-uploader', [FileController::class, 'ditr_file_uploader'])->name('ditr-file-uploader');
});

/** ROUTES ACTIONS */

Route::post('/import-pdf-imoveis', [PDFImportController::class, 'importPDFImoveis']);
Route::post('/import-pdf-ditr', [PDFImportController::class, 'importPDFDitr']);

Route::get('/imoveis-files/file/{acao}/{var?}', [ImovelController::class, 'aux_files']);
Route::get('/imoveis-files/{acao}/{variavel?}', [ImovelController::class, 'process_files']);

Route::get('/ditr-files/file/{acao}/{var?}', [DitrController::class, 'aux_files']);
Route::get('/ditr-files/{acao}/{variavel?}', [DitrController::class, 'process_files']);

