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



class DitrController extends Controller
{
    public function aux_files( $action, $var = null )
    {

        switch ($action) {
            case 'dirname':
                $directory = public_path( '/uncompress-files/ditr/' ) ;
                $directories = File::directories($directory);

                $directories = array_map('basename', $directories);
                return json_encode($directories);

            break;
            case 'clear':
                $directory = $this->clearDirectory( public_path( '/uncompress-files/ditr/' ) );

            break;
            case 'count':
                $return = $this->contarArquivosPDF( public_path( '/uncompress-files/ditr/'.$var )  );
                return  $return;
            break;

        }
    }

    public function process_files($action, $variavel = null )
    {

        switch ($action) {
            case 'process':
                $return = $this->processarArquivosPDF( $variavel );
                return $return;
            break;
            case 'replay':
                $return = $this->clearDirectory( public_path( '/uncompress-files/ditr/' ) );
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

        $caminho = public_path( '/uncompress-files/ditr/'.$var  );

        if (is_dir($caminho)) {
            return $this->extrairImoveisDosPDFs($var);
        }else{
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


    //TOP 50 LINHAS
    public function extrairImoveisDosPDFs($directory)
    {
        $diretorioPDFs = public_path('/uncompress-files/ditr/' . $directory);
        $diretorioCSVs = public_path('/uncompress-files/ditr/' . $directory . '/csvs');
        $nomeArquivoZip = $directory . '.zip';

        if (!is_dir($diretorioCSVs)) {
            mkdir($diretorioCSVs, 0777, true);
        }

        $arquivosPDF = glob($diretorioPDFs . '/*.pdf');
        $totalPDFs = count($arquivosPDF);

        $zip = new \ZipArchive();
        $zipPath = $diretorioPDFs . '/' . $nomeArquivoZip;
        $zip->open($zipPath, \ZipArchive::CREATE | \ZipArchive::OVERWRITE);

        foreach ($arquivosPDF as $arquivoPDF) {
            $parser = new \Smalot\PdfParser\Parser();
            $pdf = $parser->parseFile($arquivoPDF);

            // Obtenha o número total de páginas no PDF
            $pages = $pdf->getPages();
            $totalPaginas = count($pages);

            // Converte todo texto em uma string
            $textoPDF = $pdf->getText();

            // Converter a codificação para UTF-8
            $textoUTF8 = mb_convert_encoding($textoPDF, 'UTF-8', 'auto');

            // Corrigir a codificação do texto
            $textoCorrigido = iconv('UTF-8', 'ISO-8859-1//TRANSLIT', $textoUTF8);
            $textoCorrigido_unspace = trim( $textoCorrigido );
            // Quebrar o texto em linhas

            //$linhas = explode("\n", $textoCorrigido);
            //echo $textoCorrigido;
            //die();

            $textorepum = str_replace("anterior:", "anterior:--", $textoCorrigido_unspace);
            $textorepdois = str_replace("INCRA:", "INCRA:--", $textorepum);

            $textoreptres = str_replace(":", "\n", $textorepdois);

            $linhas_fr = explode("\n", $textoreptres);
           // $linhas = explode("\t", $linhas);
           // $linhas = preg_split('/[\n\t]/', $textoCorrigido);
            $linha_array = [];
            //$linha_array[22] = "";
            $i = 0;





                // Salvar cada linha em um arquivo CSV separado FOLHA DE ROSTO
                foreach ( $linhas_fr as $indice => $linha ) {
                //$linha  = trim( $linha );

                    // Dados BRUTOS por linhas
                    if ($indice == 40) {
                        // echo $indice . 'e o I'. $i;
                        // die();
                        if (str_contains($linha, "999")) {
                            $linha_array[$i] = $linha; //"A sequência '999' foi encontrada na string.";
                        } else {
                            $linha_array[40] = "0000000000"; // "A sequência '999' não foi encontrada na string.";
                            $i++;

                        }
                    }

                    if ($indice == 104) {
                        // echo $indice . 'e o I'. $i;
                        // die();
                        if (str_contains($linha, "999")) {
                            $linha_array[$i] = $linha; //"A sequência '999' foi encontrada na string.";

                        } else {
                            $linha_array[104] = "0000000000"; // "A sequência '999' não foi encontrada na string.";

                        }
                    }
                    if ($i == 105) {
                        if (str_contains($linha, "sica")) {
                            $linha_array[105] = "-";

                             $i++; //"A sequência '999' foi encontrada na string.";

                        } else {
                            $linha_array[107] = $linha; // "A sequência '999' não foi encontrada na string.";

                        }
                    }
                    if ($indice == 105) {

                         if (str_contains($linha, "Sim") || str_contains($linha, "Não")) {
                            $linha_array[106] = "-";
                            $linha_array[107] = "Passoa Física";
                             $i++; //"A sequência '999' foi encontrada na string.";

                        } else {
                            $linha_array[$i] = $linha; // "A sequência '999' não foi encontrada na string.";

                        }
                    }

                    if ($indice == 106) {

                        if (str_contains($linha, "Sim") || str_contains($linha, "Não")) {
                            $linha_array[106] = "-";
                             $i++; //"A sequência '999' foi encontrada na string.";
                        } else {
                            $linha_array[$i] = $linha; // "A sequência '999' não foi encontrada na string.";

                        }
                    }
                        $linha_array[$i] = !empty($linha) ? $linha : "";

                        $arquivoCSV = str_replace('.pdf', "-linha{$i}.csv", basename($arquivoPDF));
                        file_put_contents($diretorioCSVs . '/' . $arquivoCSV, $linha);
                        // $zip->addFile($diretorioCSVs . '/' . $arquivoCSV, $arquivoCSV);
                        $i++;

                }




        }

            foreach ($linha_array as $conut => $value) {
                # code...

                echo 'Linha ='.$conut . ' | '.utf8_encode( utf8_decode( $value ) ) . '<br>';

                if ($conut == 7) {
                    $usuario  = $value;
                }
                if ($conut == 10) {
                    $dt_impressao_hora  = $value;
                }
                if ($conut == 11) {
                    $dt_impressao_min  = $value;
                }
                if ($conut == 12) {
                    $exp  = explode("\t",$value);
                    $dt_impressao_seg = $exp[0];
                }
                if ($conut == 43) {
                    $exercicio  = $value;
                }
                if ($conut == 35) {
                    $tipo  = $value;
                }
                if ($conut == 36) {
                    $retificadora  = $value;
                }

                if ($conut == 38) {
                    $cib  = $value;
                }
                if ($conut == 40) {
                    $cod_incra  = $value;
                }
                if ($conut == 37) {
                    $nd  = $value;
                }
                if ($conut == 42) {
                    $recibo_etc  = $value;
                }
                if ($conut == 45) {
                    $dt_entrega  = $value;
                }
                if ($conut == 46) {
                    $dt_entrega_min  = $value;
                }
                if ($conut == 47) {
                    $dt_entrega_seg  = $value;
                }
                if ($conut == 34) {
                    $meio_entrega  = $value;
                }
                if ($conut == 41) {
                    if(str_contains($value, "Sim")){
                        $imune_isento  = $value;
                    }else{
                        $imune_isento  = "Não";
                    }

                }
                if ($conut == 39) {
                    $situacao  = $value;
                }

                //PAGINA 1 DOCUMENTOS CADASTRAIS
                if ($conut == 52) {
                    $nome_imovel = $value;
                }
                if ($conut == 111) {
                    $area_imovel = $value;
                }
                if ($conut == 82) {
                    $tipo_logradouro = str_replace("Logradouro", "", $value);
                }
                if ($conut == 103) {
                    $logradouro = $value;
                }
                if ($conut == 87) {
                    $array = explode("\t", $value);
                    $uf = $array[0];
                }
                if ($conut == 106) {
                    $municipio = $value;
                }
                if ($conut == 100) {
                    $cep = $value;
                }
                if ($conut == 107) {
                    $tipo_pessoa = $value;
                }
                if ($conut == 109) {
                    $condominio = $value;
                }
                if ($conut == 108) {
                    $isento = $value;
                }
                if ($conut == 112) {
                    $nome_pessoa = $value;
                }
                if ($conut == 114) {
                    $cpf = $value;
                }
                if ($conut == 127) {
                    $dt_nasc = $value;
                }
                if ($conut == 115) {
                    $num = $value;
                }
                if ($conut == 68) {
                    $bairro = $value;
                }

                // Função folha de rosto
                $array_return_fr = $this->folha_rosto( $pages, $totalPaginas);

                // Função DITR-DIAC
                $array_return_ditr = $this->ditr_diac( $pages, $totalPaginas);

                // QUANDO NÂO É ISENTO
                if($totalPaginas >= 4 ){

                    $array_return = $this->area_valor( $pages, $totalPaginas);

                }



                if((count($linha_array)-1) == $conut){



                    $content_atualizacao_cadastral  = [
                        'Nome do Imóvel Rural'              => isset( $nome_imovel ) ? $nome_imovel : '',
                        ' Área Total do Imóvel'             => isset( $area_imovel ) ? $area_imovel." ha" : '',
                        'Código do Imóvel noIncra'          => isset( $cod_incra ) ? $cod_incra : '',
                        'Tipo Logradouro'                   => isset( $tipo_logradouro ) ? $tipo_logradouro : '',
                        'Logradouro'                        => isset( $logradouro ) ? $logradouro : '',
                        'Distrito'                          => '""',
                        'UF'                                => isset( $uf ) ? $uf : '',
                        'Município'                         => isset( $municipio ) ? $municipio : '',
                        'CEP'                               => isset( $cep ) ? $cep : '',
                        'O Contribuinte é'                  => isset( $tipo_pessoa ) ? $tipo_pessoa : '',
                        'O Imóvel Pertence a um Condomínio' => isset( $condominio ) ? $condominio : '',
                        'Imóvel Imune ou Isento do ITR'     => isset( $isento ) ? $isento : '',
                        'Esta Declaração é Retificadora'    => isset( $retificadora ) ? $retificadora : '',
                        'Nome da Pessoa Física'             => isset( $nome_pessoa ) ? $nome_pessoa : '',
                        'CPF'                               => isset( $cpf ) ? $cpf : '',
                        'Data de Nascimento'                => isset( $dt_nasc ) ? $dt_nasc : '',
                        'Número'                            => isset( $num ) ? $num : '',
                        'Bairro'                            => isset( $bairro ) ? $bairro : '',
                        'DDD/Telefone'                      => '',
                        'CPF do Cônjuge'                    => '',

                    ];

                    $content_folha_rosto            = $totalPaginas >= 1 ? $array_return_fr : '';

                   // $content_atualizacao_cadastral  = $totalPaginas >= 2 ? $array_return_ditr : '';

                    $dist_area_imovel_rural         = $totalPaginas >= 4 ? $array_return['area'] : '';

                    $calc_valor_imposto             = $totalPaginas >= 4 ? $array_return['valor'] : '';

                    // print_r( $content_folha_rosto);
                    // print_r( $content_atualizacao_cadastral);
                    // echo $dist_area_imovel_rural;
                    // //echo $calc_valor_imposto;
                    if ($totalPaginas >= 4){
                        $conteudo = array_merge( $content_folha_rosto + $content_atualizacao_cadastral + $dist_area_imovel_rural + $calc_valor_imposto );
                    }else{
                        $conteudo = array_merge( $content_folha_rosto + $content_atualizacao_cadastral);
                    }
                    $arquivoCSVimovel = str_replace('.pdf', "-full.csv", basename($arquivoPDF));

                    file_put_contents($diretorioCSVs . '/' . $arquivoCSVimovel, $conteudo);

                    $content = str_replace('"', '', $conteudo);

                    $handle = fopen($diretorioCSVs . '/' . $arquivoCSVimovel, 'w');

                    // Escrever os títulos na primeira linha
                    $titulos = array_map(function ($valor) {
                        return utf8_decode($valor);
                    }, array_keys($content));

                    fputcsv($handle, $titulos);

                    // Escrever os valores na segunda linha
                    $valores = array_map(function ($valor) {

                        return utf8_decode($valor);
                    }, array_values($content));

                    fputcsv($handle, $valores);

                    fclose($handle);

                    $zip->addFile($diretorioCSVs . '/' . $arquivoCSVimovel, $arquivoCSVimovel);


                }
                $i++;
            }


        $zip->close();
        //die();
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

    // PAGINA 1
    public function folha_rosto( $pages, $totalPaginas ){

        for ($numeroPagina = 1; $numeroPagina <= $totalPaginas; $numeroPagina++) {

            // Faça o que desejar com o conteúdo da página, por exemplo, imprimir na tela:
            if($numeroPagina == 1){
                $pagina = $pages[$numeroPagina - 1];

                // Extrai o texto da página
                $textoPDF = $pagina->getText();

                // Converter a codificação para UTF-8
                $textoUTF8 = mb_convert_encoding($textoPDF, 'UTF-8', 'auto');

                // Corrigir a codificação do texto
                $textoCorrigido = iconv('UTF-8', 'ISO-8859-1//TRANSLIT', $textoUTF8);
                $textoCorrigido_unspace = trim( $textoCorrigido );

                // Quebrar o texto em linhas
                $textorepum     = str_replace("anterior:\t", "anterior:\n--\n", $textoCorrigido_unspace);
                $textorepdois   = str_replace("INCRA:\t", "INCRA:\n--\n", $textorepum);
                $texto_a        = str_replace("a:", "a|", $textorepdois);
                $texto_o        = str_replace("o:", "o|", $texto_a);
                $texto_or       = str_replace("or:", "or|", $texto_o);
                $texto_bzao     = str_replace("B:", "B|", $texto_or);
                $texto_azao     = str_replace("A:", "A|", $texto_bzao);
                $texto_dzao     = str_replace("D:", "D|", $texto_azao);
                $texto_tzao     = str_replace("T:", "T|", $texto_dzao);
                $texto_tabs     = str_replace("\t", "", $texto_tzao);
                $texto_pipes    = str_replace("|", "\n", $texto_tabs);

                $linhas_fr      = explode("\n", $texto_pipes);

                foreach ($linhas_fr as $cont_fr => $value) {
                    $value = utf8_encode($value);
                    echo 'Linha da pagina 1: '. $cont_fr . 'Valor: ' . $value . '<br>';
                    $dados_fr[$cont_fr] = $value;
                }

                //Filtros Folha de rosto
                $dat_impressa        =  explode('Data', $dados_fr[10]);
                if (strpos($dados_fr[38], "Sim") !== false) {
                    $dados_tp[39] = $dados_fr[38];
                    $dados_tp[40] = $dados_fr[39];
                    $dados_tp[41] = $dados_fr[40];
                    $dados_tp[42] = $dados_fr[41];
                    $dados_tp[43] = $dados_fr[42];
                    $dados_tp[44] = $dados_fr[43];

                    $dados_fr[38] = '';
                    $dados_fr[39] = $dados_tp[39];
                    $dados_fr[40] = $dados_tp[40];
                    $dados_fr[41] = $dados_tp[41];
                    $dados_fr[42] = $dados_tp[42];
                    $dados_fr[43] = $dados_tp[43];
                    $dados_fr[44] = $dados_tp[44];
                }


                $return = [
                    'Usuário'                       => isset( $dados_fr[7] ) ? $dados_fr[7] : '',
                    'Data/Hora de Impressao'        => isset( $dat_impressa[0] ) ? $dat_impressa[0] : '',
                    'Exercício'                     => isset( $dados_fr[41] ) ? $dados_fr[41] : '',
                    'Tipo'                          => isset( $dados_fr[33] ) ? $dados_fr[33] : '',
                    'Retificadora'                  => isset( $dados_fr[34] ) ? $dados_fr[34] : '',
                    'Número de Recibo DITR anterior'=> isset( $dados_fr[26] ) ? str_replace("--","",$dados_fr[26]) : '',
                    'CIB'                           => isset( $dados_fr[36] ) ? $dados_fr[36]  : '',
                    'Código do Imóvel no INCRA'     => isset( $dados_fr[38] ) ? $dados_fr[38] : '',
                    'ND'                            => isset( $dados_fr[35] ) ? $dados_fr[35] : '',
                    'Número do Recibo/ECT'          => isset( $dados_fr[40] ) ? $dados_fr[40] : '',
                    'Data/Hora Entrega'             => isset( $dados_fr[43] ) ? $dados_fr[43] : '',
                    'Meio de Entrega'               => isset( $dados_fr[32] ) ? $dados_fr[32] : '',
                    'Imune/Isento'                  => isset( $dados_fr[39] ) ? $dados_fr[39] : '',
                    'Situação'                      => isset( $dados_fr[37] ) ? $dados_fr[37] : '',
                ];


            }
           // die();
        //    echo '<pre>';
        //    print_r($return);
        //    die();
            return $return;

        };

    }


    // PAGINA 2
    public function ditr_diac( $pages, $totalPaginas ){

        for ($numeroPagina = 1; $numeroPagina <= $totalPaginas; $numeroPagina++) {
            $pagina = $pages[$numeroPagina - 1];

            // Extrai o texto da página
            $textoPagina = $pagina->getText();
            //$return_array = array();


            // Faça o que desejar com o conteúdo da página, por exemplo, imprimir na tela:
            if($numeroPagina == 2){

            }


            //echo '<pre>';
            //print_r($return_array);

            //die();
            return '';

        };
    }

    // PAGINAS 3 e 4
    public function area_valor( $pages, $totalPaginas ){


        // Loop para extrair o conteúdo de cada página
        for ($numeroPagina = 1; $numeroPagina <= $totalPaginas; $numeroPagina++) {
            $pagina = $pages[$numeroPagina - 1];

            // Extrai o texto da página
            $textoPagina = $pagina->getText();
            //$return_array = array();



            // Faça o que desejar com o conteúdo da página, por exemplo, imprimir na tela:
            if($numeroPagina == 3){

                $textoUTF8 = mb_convert_encoding($textoPagina, 'UTF-8', 'auto');

                // Corrigir a codificação do texto
                $textoCorrigido         = iconv( 'UTF-8', 'ISO-8859-1//TRANSLIT', $textoUTF8 );
                $textoCorrigido_unspace = trim( $textoCorrigido );
                $linhas_areas           = explode( "\n", $textoCorrigido_unspace );

                foreach ($linhas_areas as $conut_areas => $value) {

                   echo 'Linha da pagina 3 '. $conut_areas . 'Valor da linha:' . $value . '<br>';
                   $dados_area[$conut_areas] = $value;

                }

                //Filtro de variáveis e arrays
                $array_area_coverta         = explode( "\t",$dados_area[58] );
                $array_area_alagada         = explode( "\t",$dados_area[64] );
                $array_area_utilizada       = explode( "\t",$dados_area[60] );
                $array_grau_utilizacao      = explode( " (%)	",$dados_area[44] );
                $array_servidao_ambiental   = explode( "\t",$dados_area[62] );
                $array_n_car                = isset($dados_area[77]) ? explode( "\t",$dados_area[77] ) : '';
                if($array_n_car == ""){
                    $dados_area[79] = $dados_area[68];
                    $dados_area[63] = "";
                }

                $return_array['area'] = [
                    'Área Total do Imovel '                                                                 => isset( $dados_area[23] ) ? $dados_area[23] : '0,0',
                    'Área de Preservação Permanete'                                                         => isset( $dados_area[24] ) ? $dados_area[24] : '0,0',
                    'Área de Reserva Legal'                                                                 => isset( $dados_area[25] ) ? $dados_area[25] : '0,0',
                    'Área de Reserva Perticular do Patrimônio Natural (RPPN)'                               => isset( $dados_area[26] ) ? $dados_area[26] : '0,0',
                    'Área de Interesse Ecológico'                                                           => isset( $dados_area[61] ) ? $dados_area[61]  : '0,0',
                    'Área de Servidão Ambiental'                                                            => isset( $array_servidao_ambiental ) ? $array_servidao_ambiental[1]  : '0,0',
                    'Área Coberta por Florestas Nativas'                                                    => isset( $dados_area[58] ) ? $array_area_coverta[1] : '0,0',

                    'Área Alagada de Reservatório de Usinas Hidrelétricas Autorizada pelo Poder Público'    => isset( $array_area_alagada ) ? $array_area_alagada[1]  : '0,0',

                    'Área Tributável'                                                                       => isset( $dados_area[29] ) ? $dados_area[29] : '0,0',
                    'Área Ocupada com Bemfeitorias Úteis e Necessárias Destinadas à Atividade Rural'        => isset( $dados_area[28] ) ? $dados_area[28] : '0,0',
                    'Área Aproveitável'                                                                     => isset( $dados_area[27] ) ? $dados_area[27] : '0,0',

                    'Área de Produtos Vegetais'                                                             => isset( $dados_area[38] ) ? $dados_area[38] : '0,0',
                    'Área em Descanço'                                                                      => isset( $dados_area[39] ) ? $dados_area[39] : '0,0',
                    'Área de Reflorestamento (Essências Exóticas ou Nativas)'                               => isset( $dados_area[40] ) ? $dados_area[40] : '0,0',
                    'Área de Pastagem'                                                                      => isset( $dados_area[41] ) ? $dados_area[41] : '0,0',
                    'Área de Exploração Extrativa'                                                          => isset( $dados_area[42] ) ? $dados_area[42] : '0,0',
                    'Área de Atividade Granjeira ou Aquícola'                                               => isset( $dados_area[43] ) ? $dados_area[43] : '0,0',

                    'Área de Frustração de Safra ou Destruição de Pastagem por Calamidade Pública'          => isset( $dados_area[30] ) ? $dados_area[30] : '0,0',
                    'Área Utilizada da Atividade Rural'                                                     => isset( $array_area_utilizada ) ? $array_area_utilizada[1]  : '0,0',

                    'GRAU DE UTILIZAÇÃO'                                                                    => isset( $array_grau_utilizacao ) ? $array_grau_utilizacao[1]  : '0,0',
                    $dados_area[79]                                                                         => isset( $dados_area[63] ) ? $dados_area[63] : '',
                    'Número do CAR'                                                                         => isset( $array_n_car[1] ) ? $array_n_car[1] : '',

                    'Área com Demais Benfeitorias'                                                          => isset( $dados_area[52] ) ? $dados_area[52]  : '0,0',
                    'Área com Mineração (jazida/mina)'                                                      => isset( $dados_area[53] ) ? $dados_area[53]  : '0,0',
                    'Área Imprestável para Atividade Rutal Nãi Declarada de Interesse Ecológico'            => isset( $dados_area[54] ) ? $dados_area[54]  : '0,0',
                    'Área Inexplorada'                                                                      => isset( $dados_area[55] ) ? $dados_area[55]  : '0,0',
                    'Outras Áreas'                                                                          => isset( $dados_area[57] ) ? $dados_area[57]  : '0,0',
                    'Área Não Utilizada na Atividade Rural'                                                 => isset( $dados_area[56] ) ? $dados_area[56]  : '0,0',

                ];


            }


            if($numeroPagina == 4){

                $textoUTF8 = mb_convert_encoding($textoPagina, 'UTF-8', 'auto');

                // Corrigir a codificação do texto
                $textoCorrigido         = iconv( 'UTF-8', 'ISO-8859-1//TRANSLIT', $textoUTF8 );
                $textoCorrigido_unspace = trim( $textoCorrigido );
                $linhas_valores         = explode( "\n", $textoCorrigido_unspace );

                foreach ($linhas_valores as $conut_valores => $value) {
                    echo 'Linha da pagina 4 '. $conut_valores . 'Valor da linha:' . $value . '<br>';
                    $dados_valor[$conut_valores] = $value;

                }


                //Filtro de variáveis e arrays
                $array_quantidade_quotas    = explode( "\t",$dados_valor[31] );
                $array_valor_quotas         = explode( "\t",$dados_valor[32] );


                $return_array['valor'] =     [
                       'Valor Total do Imóvel'                                                          => isset( $dados_valor[17] ) ? $dados_valor[17]  : '0,0',
                       'Valor das Contruções, Instalações e Benfeitorias'                               => isset( $dados_valor[18] ) ? $dados_valor[18]  : '0,0',
                       'Valor das Culturas, Pastagens Cultivadas e Melhoradas e Florestas Plantadas'    => isset( $dados_valor[19] ) ? $dados_valor[19]  : '0,0',
                       'Valor de Terra Nua'                                                             => isset( $dados_valor[20] ) ? $dados_valor[20]  : '0,0',

                       'Valor da Terra Nua Tributável'                                                  => isset( $dados_valor[26] ) ? $dados_valor[26]  : '0,0',
                       'Aliquota (%)'                                                                   => isset( $dados_valor[27] ) ? $dados_valor[27]  : '0,0',
                       'Imposto Calculado'                                                              => isset( $dados_valor[28] ) ? $dados_valor[28]  : '0,0',
                       'Imposto Devido'                                                                 => isset( $dados_valor[29] ) ? $dados_valor[29]  : '0,0',

                       'Quantidade de Quotas'                                                           => isset( $array_quantidade_quotas[1] ) ? $array_quantidade_quotas[1]  : '0,0',
                       'Valor da Quota ou da Quota Única'                                               => isset( $array_valor_quotas[0] ) ? $array_valor_quotas[0]  : '0,0',
                    ];

            }



        }

        //echo '<pre>';
        //print_r($return_array);

        //die();
        return $return_array;

    }





    public function trataLinhas($indice, $conteudo){
        switch ($indice) {
            case '0':
                $return = $this->linha0($conteudo);
                return $return;
            break;
            case '1':
                $return = $this->linha1($conteudo);
                return $return;
            break;
            case '3':
                $return = $this->linha3($conteudo);
                return $return;
            break;
            case '4':
                $return = $this->linha4($conteudo);
                return $return;
            break;
            case '5':
                $return = $this->linha5($conteudo);
                return $return;
            break;
            case '6':
                $return = $this->linha6($conteudo);
                return $return;
            break;
            case '7':
                $return = $this->linha7($conteudo);
                return $return;
            break;
            case '8':
                $return = $this->linha8($conteudo);
                return $return;
            break;
            case '9':
                $return = $this->linha9($conteudo);
                return $return;
            break;
            case '10':
                $return = $this->linha10($conteudo);
                return $return;
            break;
            case '11':
                $return = $this->linha11($conteudo);
                return $return;
            break;
            case '12':
                $return = $this->linha12($conteudo);
                return $return;
            break;
            case '13':
                $return = $this->linha13($conteudo);
                return $return;
            break;
            case '14':
                $return = $this->linha14($conteudo);
                return $return;
            break;
            case '15':
                $return = $this->linha15($conteudo);
                return $return;
            break;
            case '16':
                $return = $this->linha16($conteudo);
                return $return;
            break;
            case '17':
                $return = $this->linha17($conteudo);
                return $return;
            break;
            case '18':
                $return = $this->linha18($conteudo);
                return $return;
            break;
            case '19':
                $return = $this->linha19($conteudo);
                return $return;
            break;
            case '20':
                $return = $this->linha20($conteudo);
                return $return;
            break;
            case '21':
                $return = $this->linha21($conteudo);
                return $return;
            break;
            case '22':
                $return = $this->linha22($conteudo);
                return $return;
            break;
            case '23':
                $return = $this->linha23($conteudo);
                return $return;
            break;
            case '24':
                $return = $this->linha24($conteudo);
                return $return;
            break;
            case '25':
                $return = $this->linha25($conteudo);
                return $return;
            break;
            case '26':
                $return = $this->linha26($conteudo);
                return $return;
            break;
            case '27':
                $return = $this->linha27($conteudo);
                return $return;
            break;
            case '28':
                $return = $this->linha28($conteudo);
                return $return;
            break;
            case '29':
                $return = $this->linha29($conteudo);
                return $return;
            break;
            case '30':
                $return = $this->linha30($conteudo);
                return $return;
            break;
            case '31':
                $return = $this->linha31($conteudo);
                return $return;
            break;
            case '32':
                $return = $this->linha32($conteudo);
                return $return;
            break;
            case '33':
                $return = $this->linha33($conteudo);
                return $return;
            break;
            case '34':
                $return = $this->linha34($conteudo);
                return $return;
            break;
            case '35':
                $return = $this->linha35($conteudo);
                return $return;
            break;
            case '36':
                $return = $this->linha36($conteudo);
                return $return;
            break;
            case '37':
                $return = $this->linha37($conteudo);
                return $return;
            break;
            case '38':
                $return = $this->linha38($conteudo);
                return $return;
            break;
            case '39':
                $return = $this->linha39($conteudo);
                return $return;
            break;
            case '40':
                $return = $this->linha40($conteudo);
                return $return;
            break;
            case '41':
                $return = $this->linha41($conteudo);
                return $return;
            break;
            case '43':
                $return = $this->linha43($conteudo);
                return $return;
            break;
            case '44':
                $return = $this->linha44($conteudo);
                return $return;
            break;
            case '45':
                $return = $this->linha45($conteudo);
                return $return;
            break;
            case '46':
                $return = $this->linha46($conteudo);
                return $return;
            break;
            case '47':
                $return = $this->linha47($conteudo);
                return $return;
            break;
            case '48':
                $return = $this->linha48($conteudo);
                return $return;
            break;
            case '49':
                $return = $this->linha49($conteudo);
                return $return;
            break;
            default:
            return '';
            break;
        }




    }

    public function linha0($conteudo){
        return $conteudo;
    }
    public function linha1($conteudo){
        return $conteudo;
    }
    public function linha3($conteudo){
        $array = explode("\t", $conteudo);
        return  $array;
    }
    public function linha4($conteudo){
        return $conteudo;
    }
    public function linha5($conteudo){
        $string_utf8 = str_replace("?", "Ã",  utf8_encode($conteudo));
        return $string_utf8;
    }
    public function linha6($conteudo){
        return $conteudo;
    }
    public function linha7($conteudo){
        return $conteudo;
    }
    public function linha8($conteudo){
        return $conteudo;
    }
    public function linha9($conteudo){
        return $conteudo;
    }
    public function linha10($conteudo){
        return $conteudo;
    }
    public function linha11($conteudo){
        return $conteudo;
    }
    public function linha12($conteudo){
        return $conteudo;
    }
    public function linha13($conteudo){
        return $conteudo;
    }
    public function linha14($conteudo){
        return $conteudo;
    }
    public function linha15($conteudo){
        return $conteudo;
    }
    public function linha16($conteudo){
        $array = explode("\t", $conteudo);
        $resultado = str_replace("BAIRRO/DISTRITO", "", $array[1]);
        return  $resultado;
    }
    public function linha17($conteudo){
        $array = explode("\t", $conteudo);
        return $array;
    }
    public function linha18($conteudo){
        return $conteudo;
    }
    public function linha19($conteudo){
        $array = explode("\t", $conteudo);
        return  $array;
    }
    public function linha20($conteudo){
        $return = '';
        return $return;
    }
    public function linha21($conteudo){
        $array = explode("\t", $conteudo);
        return  $array;
    }
    public function linha22($conteudo){
        return $conteudo;
    }
    public function linha23($conteudo){
        return $conteudo;
    }
    public function linha24($conteudo){
        return $conteudo;
    }
    public function linha25($conteudo){
        return $conteudo;
    }
    public function linha26($conteudo){
        return $conteudo;
    }
    public function linha27($conteudo){
        return $conteudo;
    }
    public function linha28($conteudo){
        return $conteudo;
    }
    public function linha29($conteudo){
        return $conteudo;
    }
    public function linha30($conteudo){
        return $conteudo;
    }
    public function linha31($conteudo){
        $array = explode("\t", $conteudo);
        return  $array[0];
    }
    public function linha33($conteudo){
        return $conteudo;
    }
    public function linha34($conteudo){
        return $conteudo;
    }
    public function linha35($conteudo){
        return $conteudo;
    }
    public function linha36($conteudo){
        return $conteudo;
    }
    public function linha37($conteudo){
        return $conteudo;
    }
    public function linha38($conteudo){
        return $conteudo;
    }
    public function linha39($conteudo){
        return $conteudo;
    }

    public function linha40($conteudo){
        return $conteudo;
    }

    public function linha41($conteudo){
        return $conteudo;
    }
    public function linha43($conteudo){
        return $conteudo;
    }
    public function linha44($conteudo){
        return $conteudo;
    }

    public function linha45($conteudo){
        return $conteudo;
    }

    public function linha46($conteudo){
        return $conteudo;
    }

    public function linha47($conteudo){
        $string_utf8 = str_replace("haÁREA", "ha",  utf8_encode($conteudo));
        return $string_utf8;
    }

    public function linha48($conteudo){
        return $conteudo;
    }
    public function linha49($conteudo){
        return $conteudo;
    }





// TOP 100 LINHAS
// public function extrairImoveisDosPDFs($directory)
// {
//     $diretorioPDFs = public_path('/uncompress-files/' . $directory);
//     $diretorioCSVs = public_path('/uncompress-files/' . $directory . '/csvs');
//     $nomeArquivoZip = md5($directory) . '.zip';

//     if (!is_dir($diretorioCSVs)) {
//         mkdir($diretorioCSVs, 0777, true);
//     }

//     $arquivosPDF = glob($diretorioPDFs . '/*.pdf');
//     $totalPDFs = count($arquivosPDF);

//     $zip = new \ZipArchive();
//     $zipPath = $diretorioCSVs . '/' . $nomeArquivoZip;
//     $zip->open($zipPath, \ZipArchive::CREATE | \ZipArchive::OVERWRITE);

//     foreach ($arquivosPDF as $arquivoPDF) {
//         $parser = new \Smalot\PdfParser\Parser();
//         $pdf = $parser->parseFile($arquivoPDF);

//         $textoPDF = $pdf->getText();

//         // Converter a codificação para UTF-8
//         $textoUTF8 = mb_convert_encoding($textoPDF, 'UTF-8', 'auto');

//         // Corrigir a codificação do texto
//         $textoCorrigido = iconv('UTF-8', 'ISO-8859-1//TRANSLIT', $textoUTF8);

//         // Quebrar o texto em linhas usando expressão regular
//         $linhas = preg_split('/[\n\t]/', $textoCorrigido);

//         // Adicionar quebra de linha após a sequência de 8 asteriscos
//         $linhas = array_map(function ($linha) {
//             return str_replace('********', "********\n", $linha);
//         }, $linhas);

//         // Salvar cada linha em um arquivo CSV separado
//         foreach ($linhas as $indice => $linha) {
//             $linha = trim($linha);
//             if (!empty($linha)) {
//                 $arquivoCSV = str_replace('.pdf', "-linha{$indice}.csv", basename($arquivoPDF));
//                 file_put_contents($diretorioCSVs . '/' . $arquivoCSV, $linha);
//                 $zip->addFile($diretorioCSVs . '/' . $arquivoCSV, $arquivoCSV);
//             }
//         }
//     }

//     $zip->close();

//     if (file_exists($zipPath)) {
//         return response()->json([
//             'message' => 'Arquivo ZIP criado com sucesso',
//             'total_arquivos_pdf' => $totalPDFs,
//             'zip_path' => $zipPath,
//         ]);
//     } else {
//         return response()->json(['error' => 'Erro ao criar arquivo ZIP'], 500);
//     }
// }


}
