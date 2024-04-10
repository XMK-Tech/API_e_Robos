<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\File;
use Spatie\PdfToText\Pdf;
use Illuminate\Support\Facades\Storage;
use setasign\Fpdi\Fpdi;
use setasign\Fpdi\PdfParser\StreamReader;
use setasign\Fpdi\Tcpdf\Fpdi as TcpdfFpdi;
use Dompdf\Dompdf;
use Smalot\PdfParser;
use Dompdf\Cpdf;
use dompdf\Options;
use DOMText;
use ZipArchive;
use Smalot\PdfParser\Parser;
use tabula\Tabula;



class ImovelController extends Controller
{
    public function aux_files( $action, $var = null )
    {

        switch ($action) {
            case 'dirname':
                $directory = public_path( '/uncompress-files/imoveis/' ) ;
                $directories = File::directories($directory);

                $directories = array_map('basename', $directories);
                return json_encode($directories);

            break;
            case 'clear':
                $directory = $this->clearDirectory( public_path( '/uncompress-files/imoveis/' ) );

            break;
            case 'count':
                $return = $this->contarArquivosPDF( public_path( '/uncompress-files/imoveis/'.$var )  );
                return  $return;
            break;

        }
    }

    public function process_files($action, $variavel = null )
    {

        switch ($action) {
            case 'process':
                //$return = $this->getDirectoryNames( public_path( '/uncompress-files/' ) );
                $return = $this->processarArquivosPDF( $variavel );
                return $return;
            break;
            case 'replay':
                $return = $this->clearDirectory( public_path( '/uncompress-files/imoveis/' ) );
                return $return;
            break;
            case 'download_link':
                $return = $this->processarArquivosPDF( $variavel );
                return  $return;
            break;

        }


    }

    public function processarArquivosPDF($var = null)
    {
        $caminho = public_path('/uncompress-files/imoveis/' . $var);

        if (is_dir($caminho)) {
            return $this->extrairImoveisDosPDFs($var);
        } else {
            return false;
        }
    }

    public function clearDirectory( $directory )
    {
        if ( File::isDirectory( $directory ) ) {
             File::cleanDirectory( $directory );
            return response()->json([
                'clear' => true
            ]);
        }else{
            return response()->json([
                'clear' => false
            ]);
        }

    }

    public function getDirectoryNames( $directory )
    {

        $directories = [];

        if (File::isDirectory($directory)) {
            $directories = File::directories($directory);
            $directories = array_map('basename', $directories);
        }

       return $directories[0];
    }

    public function contarArquivosPDF($var = null)
    {

        $caminho = $var;
        $totalArquivos = 0;
        $totalPDF = 0;

        if (is_dir($caminho)) {
            $arquivos = scandir($caminho);

            foreach ($arquivos as $arquivo) {
                if (pathinfo($arquivo, PATHINFO_EXTENSION) === 'pdf') {
                    $totalPDF++;
                }
                $totalArquivos++;
            }
        }

        return response()->json([
            'total_arquivos' => $totalArquivos,
            'total_pdf' => $totalPDF
        ]);
    }


    public function extrairImoveisDosPDFs($directory)
    {

        $diretorioPDFs = public_path('/uncompress-files/imoveis/' . $directory);
        $diretorioCSVs = public_path('/uncompress-files/imoveis/' . $directory . '/csvs');
        $nomeArquivoZip = $directory . '.zip';

        if (!is_dir($diretorioCSVs)) {
            mkdir($diretorioCSVs, 0777, true);
        }

        $arquivosPDF = glob($diretorioPDFs . '/*.pdf');
        $totalPDFs = count($arquivosPDF);

        $zip = new \ZipArchive();
        $zipPath = $diretorioPDFs . '/' . $nomeArquivoZip;
        $zip->open($zipPath, \ZipArchive::CREATE | \ZipArchive::OVERWRITE);

        $imoveis = [];
        $proprietarios = [];


        $file_count = 0;

        foreach ($arquivosPDF as $arquivoPDF) {
            $parser = new \Smalot\PdfParser\Parser();
            $pdf = $parser->parseFile($arquivoPDF);
            $termos = [];
            $textoPDF = $pdf->getText();

            //Remove os ********
            //$textoSemAsteriscos = str_replace("********", " ", $textoPDF);

            // Converter a codificação para UTF-8
            //$textoUTF8 = mb_convert_encoding($textoSemAsteriscos, 'UTF-8', 'auto');
            $textoUTF8 = mb_convert_encoding($textoPDF, 'UTF-8', 'auto');

            // Corrigir a codificação do texto
            $textoCorrigido = iconv('UTF-8', 'ISO-8859-1//TRANSLIT', $textoUTF8);

            // Quebrar o texto em linhas
            $linhas_exp = explode("\n", $textoCorrigido);

                foreach ($linhas_exp as $key => $content) {
                // echo 'content: '.$content.'<br>';
                    $content_expo = explode("\t", $content);
                    echo 'content: '.print_r( $content_expo ) .' original:'. $content.'<br>';
                    if (is_array($content_expo)) {

                        foreach ($content_expo as $key_content => $value) {
                            $termos[] = $value;
                        }

                    }else{
                        $termos[] =  $content;
                    }


                }

                $linhas = $termos;


                // // Salvar cada linha em um arquivo CSV separado
                 foreach ($linhas as $indice => $linha) {
                //     $linha = trim($linha);
                     echo 'Indice: '. $indice .'Linha:'. $linha.'<br>';
                 }
                //     // Dados BRUTOS por linhas

                // if (!empty($linha)) {
                //     $arquivoCSV = str_replace(".pdf", "-{$indice}.csv'", basename($arquivoPDF));
                //     file_put_contents($diretorioCSVs . '/' . $arquivoCSV, $linha);
                // //     // $zip->addFile($diretorioCSVs . '/' . $arquivoCSV, $arquivoCSV);
                // }


                // ---> IMOVEL PADRÃO <--- //

                //CIB

                $cib = isset( $linhas[40] ) ? $linhas[40] : '********';

                // NOME DO IMÓVEL
                $nome_imovel = isset( $linhas[41] ) ? $linhas[41] : '********';

                // ÁREA
                $area = isset( $linhas[88] ) ? str_replace("haÁREA", "ha",  utf8_encode( $linhas[88] )) : '********';;

                // LOCALIZAÇÃO
                $localizacao = isset( $linhas[86] ) ? $linhas[86] : '********';

                // DISTRITO
                $distrito = isset( $linhas[6] ) ? $linhas[6] : '********';

                // CEP
                $cep_municipio = isset( $linhas[7] ) ? str_replace("CEP", "",  $linhas[7]) : '********';;

                // MUNICÍPIO
                $municipio_imovel = isset( $linhas[9] ) ? $linhas[9] : '********';

                // UF
                $uf_imovel = isset( $linhas[10] ) ? str_replace("UF", "",  $linhas[10]) : '********';

                // SITUAÇÃO
                $situacao = isset( $linhas[12] ) ? $linhas[12] : '********';

                // CIB VINCULADO
                $cib_vinculado = isset( $linhas[77] ) ? $linhas[77] : '********';

                // CÓDIGO DO IMÓVEL NO INCRA
                $cod_incra = isset( $linhas[72] ) ? $linhas[72] : '********';

                // ---> FIM IMOVEL <--- //


                // ---> PROPRIETARIOS PADRÃO <--- //

                //'CPF/CNPJ'
                $cpf_cnpj = isset( $linhas[69] ) ? $linhas[69] : '********';
                //'NOME'
                $nome = isset( $linhas[22] ) ? $linhas[22] : '********';
                //'TELEFONE'
                $telefone = isset( $linhas[89] ) ? $linhas[89] : '********';
                //'ENDEREÇO DE CORRESPONDÊNCIA'
                $ender_correspondencia = isset( $linhas[26] ) ? $linhas[26] : '********';
                //'NÚMERO'
                $prop_numero = isset( $linhas[29] ) ? $linhas[29] : '********';
                //'COMPLEMENTO'
                $complemento_pr = isset( $linhas[27] ) ? $linhas[27] : '********';
                //'BAIRRO/DISTRITO'
                $bairro_distrito = isset( $linhas[28] ) ? str_replace("BAIRRO/DISTRITO", "",  $linhas[28]) : '********';
                //'CEP'
                $cep_prop = isset( $linhas[32] ) ? $linhas[32] : '********';
                //'MUNICÍPIO'
                $municipio_prop = isset( $linhas[33] ) ? $linhas[33] : '********';
                //'UF'
                $uf_prop = isset( $linhas[34] ) ? str_replace("UF", "",  $linhas[34]) : '********';
                //'ENDEREÇO DE CADASTRO DE PESSOA FÍSICA/JURÍDICA'
                $ender_pf = isset( $linhas[55] ) ? $linhas[55] : '********';
                //'NÚMERO_2'
                $numero_ender_pf = isset( $linhas[47] ) ? $linhas[47] : '********';
                //'COMPLEMENTO_2'
                $complemento_ender_pf = isset( $linhas[50] ) ? $linhas[50] : '********';
                //'BAIRRO/DISTRITO_3'
                $bairro_ender_pf = isset( $linhas[57] ) ? $linhas[57] : '********';
                //'CEP_4'
                $cep_ender_pf = isset( $linhas[59] ) ? $linhas[59] : '********';
                //'MUNICÍPIO_5'
                $municipio_ender_pf = isset( $linhas[42] ) ? $linhas[42] : '********';
                //'UF_6'
                $uf_ender_pf = isset( $linhas[60] ) ? $linhas[60] : '********';
                //'NOME DO INVENTARIANTE'
                $nome_invent = isset( $linhas[39] ) ? $linhas[39] : '********';
                //'CPF_INVENTARIANTE'
                $cpf_invent = isset( $linhas[38] ) ? str_replace("CPF", "", $linhas[38]) : '********';
                //'NOME DO REPRESENTANTE LEGAL'
                $nome_rep_legal = isset( $linhas[90] ) ? $linhas[90] : '********';
                //'CPF_REPRESENTANTE_LEGAL'
                $cpf_rep_legal = isset( $linhas[90] ) ? $linhas[90] : '********';
                //'EXERCÍCIOS COM IMUNIDADE / ISENÇÃO'
                $exe_imunidade = isset( $linhas[104] ) ? $linhas[104] : '********';
                //'MOTIVO'
                $motivo = isset( $linhas[101] ) ? $linhas[101] : '********';
                //'DATA INÍCIO'
                $data_inicio = isset( $linhas[99] ) ? $linhas[99] : '********';
                //'DATA FIM'
                $data_fim = isset( $linhas[100] ) ? $linhas[100] : '********';

                // ---> FIM PROPRIETARIOS <--- //


                //if ((count($linhas) - 1) == $indice) {

                    $imovel = [
                        'CIB' => $cib,
                        'NOME DO IMÓVEL' => $nome_imovel,
                        'RUA ' => $localizacao,
                        'DISTRITO' => $distrito,
                        'CIDADE' => $municipio_imovel,
                        'SITUAÇÃO' => $situacao,
                        'CÓDIGO DO IMÓVEL NO INCRA' => '********',
                        'ÁREA ' => $area,
                        'CEP' => $cep_municipio,
                        '' => "",
                        'CIB VINCULADO' => $cib_vinculado,
                    ];

                    $imoveis[] = $imovel;

                    $proprietario = [
                        'CIB' => $cib,
                        'CPF/CNPJ' => $cpf_cnpj,
                        'NOME' => $nome,
                        'TELEFONE' => $telefone,
                        'ENDEREÇO DE CORRESPONDÊNCIA' => $ender_correspondencia,
                        'NÚMERO' => $prop_numero,
                        'COMPLEMENTO' =>  $complemento_pr,
                        'BAIRRO/DISTRITO' => $bairro_distrito,
                        'CEP' => $cep_prop,
                        'MUNICÍPIO' => $municipio_prop,
                        'UF' => $uf_prop,
                        'ENDEREÇO DE CADASTRO DE PESSOA FÍSICA/JURÍDICA' => $ender_pf,
                        'NÚMERO_2' => $numero_ender_pf,
                        'COMPLEMENTO_2' => $complemento_ender_pf,
                        'BAIRRO/DISTRITO_3' => $bairro_ender_pf,
                        'CEP_4' => $cep_ender_pf ,
                        'MUNICÍPIO_5' => $municipio_ender_pf,
                        'UF_6' => $uf_ender_pf,
                        'NOME DO INVENTARIANTE' => $nome_invent,
                        'CPF_INVENTARIANTE' => $cpf_invent,
                        'NOME DO REPRESENTANTE LEGAL' => $nome_rep_legal,
                        'CPF_REPRESENTANTE_LEGAL' => $cpf_rep_legal,
                        'EXERCÍCIOS COM IMUNIDADE / ISENÇÃO' => $exe_imunidade,
                        'MOTIVO' => $motivo,
                        'DATA INÍCIO' => $data_inicio,
                        'DATA FIM' => $data_fim,


                    ];

                    $proprietarios[] = $proprietario;
                //}
        }

         print_r($imoveis);
// die;
        // Salvar arquivo imoveis.csv
        $imoveisCSV = $diretorioCSVs . '/imoveis.csv';
        $this->gerarArquivoCSV($imoveisCSV, $imoveis);

        // Salvar arquivo proprietarios.csv
        $proprietariosCSV = $diretorioCSVs . '/proprietarios.csv';
        $this->gerarArquivoCSV($proprietariosCSV, $proprietarios);

        $zip->addFile($imoveisCSV, 'imoveis.csv');
        $zip->addFile($proprietariosCSV, 'proprietarios.csv');
        $zip->close();
//  die();
        if (file_exists($zipPath)) {
            return response()->json([
                'message' => 'Arquivo ZIP criado com sucesso',
                'total_arquivos_pdf' => $totalPDFs,
                'zip_path' => $zipPath,
            ]);
        } else {
            return response()->json(['error' => 'Erro ao criar arquivo ZIP'], 500);
        }
    }



    // private function gerarArquivoCSV($caminho, $dados)
    // {
    //     //
    //     $handle = fopen($caminho, 'w');

    //     // Escrever os títulos na primeira linha
    //     $titulos = array_map(function ($valor, $index) use ($dados) {
    //         $last = count($dados[0]) - 1;
    //         return ($index === $last) ? utf8_encode($valor) : utf8_encode($valor) . '╣';
    //     }, array_keys($dados[0]), array_keys($dados[0]));

    //     fwrite($handle, implode("\t", $titulos) . "\n");

    //     // Escrever os valores nas linhas subsequentes
    //     foreach ($dados as $linha) {
    //         $valores = array_map(function ($valor, $index) use ($linha) {
    //             $last = count($linha) - 1;
    //             return ($index === $last) ? utf8_encode($valor) : utf8_encode($valor) . '╣';
    //         }, array_values($linha), array_keys($linha));

    //         fwrite($handle, implode("\t", $valores) . "\n");
    //     }

    //     fclose($handle);
    // }

    private function gerarArquivoCSV($caminho, $dados)
    {
        $handle = fopen($caminho, 'w');

        // Escrever os títulos na primeira linha
        $titulos = array_keys($dados[0]);
        $numTitulos = count($titulos);

        for ($i = 0; $i < $numTitulos; $i++) {
            $titulo = $titulos[$i];
            fwrite($handle, $titulo);

            // Adicione '╣' somente se não for a última coluna
            if ($i < $numTitulos - 1) {
                fwrite($handle, '╣');
            }
        }
        fwrite($handle, "\n");

        // Escrever os valores nas linhas subsequentes
        foreach ($dados as $linha) {
            $valores = array_values($linha);
            $numValores = count($valores);

            for ($i = 0; $i < $numValores; $i++) {
                $valor = utf8_encode($valores[$i]);
                fwrite($handle, $valor);

                // Adicione '╣' somente se não for o último valor na linha
                if ($i < $numValores - 1) {
                    fwrite($handle, '╣');
                }
            }
            fwrite($handle, "\n");
        }

        fclose($handle);
    }

}
