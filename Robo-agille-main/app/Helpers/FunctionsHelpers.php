<?php // Code within app\Helpers\FunctionsHelpers.php

namespace App\Helpers;

class FunctionsHelpers
{


    # INDICE ############################
    # ! ge_navegador				    #
    # ! hours_to_secounds				#
    # ! secounds_to_hours				#
    # ! array_meses						#
    # ! gerar_token						#
    # ! upload_arquivo					#
    # ! mult_upload_arquivos			#
    # ! list_anexos						#
    # ! limpa_caracter_especial			#
    # ! mask_cpf						#
    # ! mask_cnpj						#
    # ! valida_sessao					#
    # ! traduz_data						#
    # ! data_br							#
    # ! loading_page					#
    # ! conv_real						#
    # ! ajusta_nome						#
    # ! sigla_estados					#
    # ! mask_telddd						#
    # ! mask_cepviii 00000-000			#
    #####################################

    public function conv_timestamp_date_mill($timstamp)
    {

        $new_date_tmsp = substr($timstamp, 6, -9);
        $ts = $new_date_tmsp;
        $date = new \DateTime("@$ts");
        $data_utc = $date->format('d-m-Y H:i:s');
        //$date_br = date_create($data_utc, timezone_open('America/Sao_Paulo'));

        //die();
        ///$date_br = strtotime('-3 hour', $date_br->format('H'));

        return $data_utc;
    }




    public function get_navegador()
    {
        $useragent = $_SERVER['HTTP_USER_AGENT'];
        if (preg_match('|MSIE ([0-9].[0-9]{1,2})|', $useragent, $matched)) {
            $browser_version = $matched[1];
            $browser = 'IE';
        } elseif (preg_match('|Opera/([0-9].[0-9]{1,2})|', $useragent, $matched)) {
            $browser_version = $matched[1];
            $browser = 'Opera';
        } elseif (preg_match('|Firefox/([0-9\.]+)|', $useragent, $matched)) {
            $browser_version = $matched[1];
            $browser = 'Firefox';
        } elseif (preg_match('|Chrome/([0-9\.]+)|', $useragent, $matched)) {
            $browser_version = $matched[1];
            $browser = 'Chrome';
        } elseif (preg_match('|Safari/([0-9\.]+)|', $useragent, $matched)) {
            $browser_version = $matched[1];
            $browser = 'Safari';
        } else {
            $browser_version = 0;
            $browser = 'other';
        }
        return "$browser $browser_version";
    }


    #CONVERTER HORAS PARA SEGUNDOS;

    public function hours_to_secounds($horario)
    {
        $horario = $horario;
        $partes_hr = explode(":", $horario);
        $segundos = $partes_hr[0] * 3600 + $partes_hr[1] * 60 + $partes_hr[2];

        return $segundos;
    }


    #CONVERTER SEGUNDOS PARA FORMATO HORAS;

    public function secounds_to_hours($segundos)
    {

        $total        = $segundos;
        $horas        = floor($total / 3600);
        $minutos      = floor(($total - ($horas * 3600)) / 60);
        $segundos     = floor($total % 60);

        $horas        = ($horas < 10) ? '0' . $horas : $horas;
        $minutos      = ($minutos < 10) ? '0' . $minutos : $minutos;
        $segundos     = ($segundos < 10) ? '0' . $segundos : $segundos;

        $formato_hrs = $horas . ":" . $minutos . ":" . $segundos;

        return ($formato_hrs);
    }


    #Array com todos os meses;

    public function array_meses()
    {
        $meses = array(
            1 => "Janeiro",
            2 => "Fevereiro",
            3 => "Março",
            4 => "Abril",
            5 => "Maio",
            6 => "Junho",
            7 => "Julho",
            8 => "Agosto",
            9 => "Setembro",
            10 => "Outubro",
            11 => "Novembro",
            12 => "Dezembro"
        );

        return $meses;
    }


    #Gerar token;

    public function gerar_token()
    {
        $token = substr(MD5(date('d-m-Y h:s:i')), 0, 10);

        return $token;
    }



    public function upload_arquivo($arquivo, $caminho)
    {

        if (!(empty($arquivo))) {

            $arquivo_minusculo = strtolower($arquivo['name']);
            $caracteres = array("ç", "~", "^", "]", "[", "{", "}", ";", ":", "´", ",", ">", "<", "-", "/", "|", "@", "$", "%", "ã", "â", "á", "à", "é", "è", "ó", "ò", "+", "=", "*", "&", "(", ")", "!", "#", "?", "`", "ã", " ", "©");

            $arquivo_tratado = str_replace($caracteres, "", $arquivo_minusculo);
            $arquivo['name'] = $arquivo_tratado;
            $destino = $caminho . "/" . $arquivo_tratado;
            if (move_uploaded_file($arquivo['tmp_name'], $destino)) {
                echo "<script>window.alert('Arquivo enviado com sucesso.');</script>";
                return $arquivo;
            } else {
                echo "<script>window.alert('Erro ao enviar o arquivo');</script>";
                return $arquivo;
            }
        }
    }



    public function mult_upload_arquivos($arquivos, $caminho_upload)
    {

        if (!is_dir($caminho_upload)) {
            mkdir($caminho_upload, 0777, true);
            chmod($caminho_upload, 0777);
        }

        $i = 0;
        foreach ($arquivos['arquivos']['name'] as $arqs) {
            if (!(empty($arqs))) {
                $docs = $arqs;

                $arquivo_minusculo = strtolower($docs);
                $caracteres = array("ç", "~", "^", "]", "[", "{", "}", ";", ":", "´", ",", ">", "<", "-", "/", "|", "@", "$", "%", "ã", "â", "á", "à", "é", "è", "ó", "ò", "+", "=", "*", "&", "(", ")", "!", "#", "?", "`", "ã", " ", "©");

                $map = array('á' => 'a', 'à' => 'a', 'ã' => 'a', 'â' => 'a', 'é' => 'e', 'ê' => 'e', 'í' => 'i', 'ó' => 'o', 'ô' => 'o', 'õ' => 'o', 'ú' => 'u', 'ü' => 'u', 'ç' => 'c', 'Á' => 'A', 'À' => 'A', 'Ã' => 'A', 'Â' => 'A', 'É' => 'E', 'Ê' => 'E', 'Í' => 'I', 'Ó' => 'O', 'Ô' => 'O', 'Õ' => 'O', 'Ú' => 'U', 'Ü' => 'U', 'Ç' => 'C');

                $arquivo_tratado = str_replace($caracteres, "", $arquivo_minusculo);
                $arquivo_tratado = strtr($arquivo_tratado, $map);
                $destino = $caminho_upload . "/" . $arquivo_tratado;

                if (move_uploaded_file($arquivos['arquivos']['tmp_name'][$i], $destino)) {
                    // echo "<script>window.alert('Arquivo enviado com sucesso.');</script>";

                } else {
                    echo "<script>window.alert('Erro ao enviar o arquivo');</script>";
                }
            }
            $i++;
        }
    }



    public function list_anexos($caminho_anexo, $url_anexo, $del_arq = FALSE)
    {

        if (is_dir($caminho_anexo)) {
            $anexo_arq = scandir($caminho_anexo);
        }

        $htmlanexo = '<div class="innerAll bg-gray border-top">';
        if (isset($anexo_arq)) {

            $i = 0;
            foreach ($anexo_arq as $anexo) {
                if ($anexo != '.' && $anexo != '..') {
                    $btn_delArqs = "";
                    if (!empty($del_arq)) {
                        $btn_delArqs = "<a href='" . env('base_url') . $del_arq . $anexo . "'><i class='fa fa-times'></i></a>";
                    }

                    $ext = explode('.', $anexo);
                    $ext = strtolower(end($ext));

                    $htmlanexo .= '
						<div class="media inline-block margin-none">
							<div class="innerLR">
								<i class="fa fa-paperclip pull-left fa-2x"></i>
								<div class="media-body">
									<div>
										<a target="_blank" href="' . env('base_url') . $url_anexo . '/' . $anexo . '" class="strong text-regular">' . $anexo . '</a> ' . $btn_delArqs . '
									</div>
								</div>
								<div class="clearfix"></div>
							</div>
						</div>';
                }
            }

            $htmlanexo .= '</div>';
        }

        #Se $htmlanexo estiver carregada;
        if (!empty($anexo_arq[2])) {
            return $htmlanexo;
        }
    }



    public function limpa_caracter_especial($valor)
    {
        $valor = trim($valor);

        $valor = str_replace(".", "", $valor);
        $valor = str_replace(",", "", $valor);
        $valor = str_replace("-", "", $valor);
        $valor = str_replace("/", "", $valor);
        $valor = str_replace("(", "", $valor);
        $valor = str_replace(")", "", $valor);
        $valor = str_replace(" ", "", $valor);
        $valor = str_replace("'", "", $valor);
        $valor = str_replace('"', "", $valor);
        $valor = str_replace("%", "", $valor);
        $valor = str_replace(":", "", $valor);

        $valor = str_replace("á", "a", $valor);
        $valor = str_replace("à", "a", $valor);
        $valor = str_replace("Á", "A", $valor);
        $valor = str_replace("À", "A", $valor);
        $valor = str_replace("â", "a", $valor);
        $valor = str_replace("Â", "A", $valor);

        $valor = str_replace("ó", "o", $valor);
        $valor = str_replace("ò", "O", $valor);
        $valor = str_replace("Ó", "O", $valor);
        $valor = str_replace("Ò", "O", $valor);
        $valor = str_replace("ô", "o", $valor);
        $valor = str_replace("Ô", "O", $valor);

        $valor = str_replace("é", "e", $valor);
        $valor = str_replace("è", "e", $valor);
        $valor = str_replace("É", "E", $valor);
        $valor = str_replace("È", "E", $valor);
        $valor = str_replace("ê", "e", $valor);
        $valor = str_replace("Ê", "E", $valor);

        $valor = str_replace("í", "i", $valor);
        $valor = str_replace("ì", "i", $valor);
        $valor = str_replace("Í", "I", $valor);
        $valor = str_replace("Ì", "I", $valor);

        return $valor;
    }



    public function valida_sessao()
    {

        if (!isset($_SESSION)) {
            session_start();

        }


    }



    public function traduz_data()
    {
        #Data e hora no formato brasileiro;
        header('Content-type: text/html; charset=utf-8');
        setlocale(LC_ALL, 'pt_BR.utf-8', 'pt_BR', 'Portuguese_Brazil');
        date_default_timezone_set('America/Sao_Paulo');
    }



    public function data_br($data)
    {
        if ($data == '') {
            $data_br = '0';
            return $data_br;
        } else {        //$data_br = date_format($data, 'd-m-Y H:i:s');
            $myDateTime = \DateTime::createFromFormat('Y-m-d H:i:s', $data);
            $data_br = $myDateTime->format('d-m-Y H:i:s');
            return $data_br;
        }

    }


    public function conv_real($data)
    {
        if ($data == '') {
            $data_real = '0';
            return $data_real;
        } else {        //$data_br = date_format($data, 'd-m-Y H:i:s');
            $myData = number_format($data, 2, ',', '.');
            return $myData;
        }


    }


    public function lgAPImill()
    {
        $get_login = curl_init();

        curl_setopt_array($get_login, array(
            CURLOPT_PORT => "6017",
            CURLOPT_URL => "http://192.1.161.126:6017/api/login",
            CURLOPT_RETURNTRANSFER => true,
            CURLOPT_ENCODING => "",
            CURLOPT_MAXREDIRS => 10,
            CURLOPT_TIMEOUT => 30,
            CURLOPT_HTTP_VERSION => CURL_HTTP_VERSION_1_1,
            CURLOPT_CUSTOMREQUEST => "GET",
            CURLOPT_HTTPHEADER => array(
                "Accept: */*",
                "Accept-Encoding: gzip, deflate",
                "Cache-Control: no-cache",
                "Connection: keep-alive",
                "Host: 192.1.161.126:6017",
                "Postman-Token: 0bff4596-8652-4d87-bfb6-300a89b91c0b,c45b7fc6-0083-43ca-86b8-d0a30224fcf3",
                "User-Agent: PostmanRuntime/7.17.1",
                "cache-control: no-cache",
                "wts-authorization: FADD837323/76B7#$4B@8"
            ),
        ));

        $response = curl_exec($get_login);
        $err = curl_error($get_login);

        curl_close($get_login);

        if ($err) {
            echo "cURL Error #:" . $err;
        } else {
            $response = json_decode($response);
            if (!empty($response->error)) {

                echo '<script>alert("' . $response->error->message->value . '")</script>';
                redirect(env('base_url') . ('err_500'), 'refresh');
            } else {

                $ret = $response->session;
                return $ret;
            }
        }
    }



    public function ajusta_nome($data)
    {

        $array =    str_word_count($data, 1);

        $nome_composto = '';
        foreach ($array as $key => $value) {
            $value = strtolower($value);
            if ($value == 'da' || $value == 'das' || $value == 'do' || $value == 'dos' || $value == 'de' || $value == 'e') {
                $nome_composto .= $value;
            } else {
                $nome_composto .= ucfirst(strtolower($value));
            }
            $nome_composto .= ' ';
        }
        return $nome_composto;
    }



    public function sigla_estados($data)
    {
        $estado = '';
        switch ($data) {
            case 'Acre':
                $estado = 'AC';
                break;
            case 'Alagoas':
                $estado = 'AL';
                break;
            case 'Amapá':
                $estado = 'AP';
                break;
            case 'Amazonas':
                $estado = 'AM';
                break;
            case 'Bahia':
                $estado = 'BA';
                break;
            case 'Ceará':
                $estado = 'CE';
                break;
            case 'Distrito Federal':
                $estado = 'DF';
                break;
            case 'Espírito Santo':
                $estado = 'ES';
                break;
            case 'Goiás':
                $estado = 'GO';
                break;
            case 'Maranhão':
                $estado = 'MA';
                break;
            case 'Mato Grosso':
                $estado = 'MT';
                break;
            case 'Mato Grosso do Sul':
                $estado = 'MS';
                break;
            case 'Minas Gerais':
                $estado = 'MG';
                break;
            case 'Pará':
                $estado = 'PA';
                break;
            case 'Paraíba':
                $estado = 'PB';
                break;
            case 'Paraná':
                $estado = 'PR';
                break;
            case 'Pernambuco':
                $estado = 'PE';
                break;
            case 'Piauí':
                $estado = 'PI';
                break;
            case 'Rio de Janeiro':
                $estado = 'RJ';
                break;
            case 'Rio Grande do Norte':
                $estado = 'RN';
                break;
            case 'Rio Grande do Sul':
                $estado = 'RS';
                break;
            case 'Rondônia':
                $estado = 'RO';
                break;
            case 'Rorâima':
                $estado = 'RR';
                break;
            case 'Santa Catarina':
                $estado = 'SC';
                break;
            case 'São Paulo':
                $estado = 'SP';
                break;
            case 'Sergipe':
                $estado = 'SE';
                break;
            case 'Tocantins':
                $estado = 'TO';
                break;
        }
        return $estado;
    }


    public function mask_cpf($cpf)
    {
        $cpf = $this->limpa_caracter_especial($cpf);
        # Retorna os 3 primeiros
        $primpart_cpf = substr($cpf, 0, 3);

        # Retorna os do 3 a 6 próximos
        $segpart_cpf = substr($cpf, 3, 3);

        # Retorna os do 6 a 9 próximos
        $tercpart_cpf = substr($cpf, 6, 3);

        # Retorna os do 9 a 11 próximos
        $quarpart_cpf = substr($cpf, 9, 2);

        $mask_cpf = $primpart_cpf . '.' . $segpart_cpf . '.' . $tercpart_cpf . '-' . $quarpart_cpf;

        return $mask_cpf;
    }



    public function mask_cnpj($cnpj)
    {
        $cnpj = $this->limpa_caracter_especial($cnpj);
        # Retorna os 3 primeiros
        $primpart_cnpj = substr($cnpj, 0, 3);

        # Retorna os do 4 a 6 próximos
        $segpart_cnpj = substr($cnpj, 3, 3);

        # Retorna os do 7 a 9 próximos
        $tercpart_cnpj = substr($cnpj, 6, 3);

        # Retorna os do 10 a 13 próximos
        $quarpart_cnpj = substr($cnpj, 9, 4);

        # Retorna os do 14 a 15 próximos
        $quintpart_cnpj = substr($cnpj, 13, 2);

        $mask_cnpj = $primpart_cnpj . '.' . $segpart_cnpj . '.' . $tercpart_cnpj . '/' . $quarpart_cnpj . '-' . $quintpart_cnpj;

        return $mask_cnpj;
    }


    public function mask_telddd($tel)
    {
        $tel = $this->limpa_caracter_especial($tel);
        # Retorna os 2 primtiros
        $ddd = substr($tel, 0, 2);

        # Retorna os 4 próximos
        $primpt_tel = substr($tel, 2, 5);

        # Retorna os 4 ultimos
        $segpt_tel = substr($tel, 7, 10);

        $mask_tel = '(' . $ddd . ')' . $primpt_tel . '-' . $segpt_tel;

        return $mask_tel;
    }



    public function mask_cepviii($data)
    {
        $data = $this->limpa_caracter_especial($data);
        # Retorna os 5 primtiros digitos
        $primpt_cep = substr($data, 0, 5);

        # Retorna os 3 ultimos
        $segpt_cep = substr($data, 5, 9);

        $mask_cep = $primpt_cep . '-' . $segpt_cep;

        return $mask_cep;
    }


    public function reduz_str($str, $tamanho)
    {
        $str_reduz = substr($str, 0, $tamanho);

        return $str_reduz;
    }
}
