<?php

namespace App\Helpers\Files;

use Carbon\Carbon;
use Error;

class UnzipFileHelper
{
    public function index($file, $path)
    {
        // Define o diretório de destino baseado na data e hora
        $timestamp = Carbon::now()->format('YmdHis');
        $destinationPath = $path . $timestamp;

        // Cria o diretório de destino
        if (!file_exists($destinationPath)) {
            mkdir($destinationPath, 0777, true);
        }

        // Extrai o arquivo WinZip
        $zip = new \ZipArchive;
        if ($zip->open($file) === true) {
            $zip->extractTo($destinationPath);
            $zip->close();
            return $destinationPath;
        } else {
            return "Falha ao abrir o arquivo WinZip.";
        }
    }
}
