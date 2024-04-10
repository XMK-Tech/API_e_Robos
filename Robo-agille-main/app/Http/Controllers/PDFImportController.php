<?php

namespace App\Http\Controllers;

use App\Helpers\Files\UnzipFileHelper;
use Illuminate\Http\Request;


class PDFImportController extends Controller
{
    public function importPDFImoveis(Request $request)
    {

        $uploadDir = public_path( '/uncompress-files/imoveis/' ); // Pasta de destino para o upload
        $zipFile = $request->file('file');

        $unzipFile = new unzipFileHelper($zipFile);
        $unzipFile->index($zipFile,$uploadDir);

 }

    public function importPDFDitr(Request $request)
    {

        $uploadDir = public_path( '/uncompress-files/ditr/' ); // Pasta de destino para o upload
        $zipFile = $request->file('file');

        $unzipFile = new unzipFileHelper($zipFile);
        $unzipFile->index($zipFile,$uploadDir);
    }

}
