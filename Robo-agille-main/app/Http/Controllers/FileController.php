<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use Illuminate\Support\Facades\File;

class FileController extends Controller
{ /*
    // Form Elements - Input
    public function input()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Form Elements"], ['name' => "Input"]
        ];
        return view('/content/forms/form-elements/form-input', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Elements - Input-groups
    public function input_groups()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Form Elements"], ['name' => "Input Groups"]
        ];
        return view('/content/forms/form-elements/form-input-groups', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Elements - Input-mask
    public function input_mask()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Form Elements"], ['name' => "Input Mask"]
        ];
        return view('/content/forms/form-elements/form-input-mask', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Elements - Textarea
    public function textarea()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Form Elements"], ['name' => "Textarea"]
        ];
        return view('/content/forms/form-elements/form-textarea', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Elements - Checkbox
    public function checkbox()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Form Elements"], ['name' => "Checkbox"]
        ];
        return view('/content/forms/form-elements/form-checkbox', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Elements - Radio
    public function radio()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Form Elements"], ['name' => "Radio"]
        ];
        return view('/content/forms/form-elements/form-radio', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Elements - custom_options
    public function custom_options()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Form Elements"], ['name' => "Custom Options"]
        ];
        return view('/content/forms/form-elements/form-custom-options', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Elements - Switch
    public function switch()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Form Elements"], ['name' => "Switch"]
        ];
        return view('/content/forms/form-elements/form-switch', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Elements - Select
    public function select()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Form Elements"], ['name' => "Select"]
        ];
        return view('/content/forms/form-elements/form-select', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Elements - Number Input
    public function number_input()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Form Elements"], ['name' => "Number Input"]
        ];
        return view('/content/forms/form-elements/form-number-input', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

  */  // IMOVEIS File Uploader
    public function imoveis_file_uploader()
    {
        $breadcrumbs = [
            ['link' => "/home", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Conversores"], ['name' => "Imóveis"]
        ];
        return view('/content/converters/imoveis/imoveis-file-uploader', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // IMOVEIS File Uploader
    public function ditr_file_uploader()
    {
        $breadcrumbs = [
            ['link' => "/home", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Conversores"], ['name' => "DITR"]
        ];
        return view('/content/converters/ditr/ditr-file-uploader', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }
/*
    public function aux_files($action, $variavel = null )
    {

        switch ($action) {
            case 'dirname':
                $return = $this->getDirectoryNames( public_path( '/uncompress-files/'.$variavel ) );
                return $return;
            break;
            case 'clear':
                $return = $this->clearDirectory( public_path( '/uncompress-files/'.$variavel ) );
                return $return;
            break;
            case 'count':
                $return = $this->contarArquivosPDF( $variavel );
                return  $return;
            break;

        }


    }

    public function contarArquivosPDF($var = null)
    {

        $caminho = public_path( '/uncompress-files/'.$var  );
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
        echo $directory ;
        $directories = [];

        if (File::isDirectory($directory)) {
            $directories = File::directories($directory);
            $directories = array_map('basename', $directories);
        }

       return$directories[0];
    }


    // Quill Editor
    public function quill_editor()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Form Elements"], ['name' => "Quill Editor"]
        ];
        return view('/content/forms/form-elements/form-quill-editor', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Elements - Date & time Picker
    public function date_time_picker()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Form Elements"], ['name' => "Date & Time Picker"]
        ];
        return view('/content/forms/form-elements/form-date-time-picker', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Layouts
    public function layouts()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Forms"], ['name' => "Form Layouts"]
        ];
        return view('/content/forms/form-layout', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Wizard
    public function wizard()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Forms"], ['name' => "Form Wizard"]
        ];
        return view('/content/forms/form-wizard', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }

    // Form Validation
    public function validation()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Forms"], ['name' => "Form Validation"]
        ];
        return view('/content/forms/form-validation', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }
    // Form repeater
    public function form_repeater()
    {
        $breadcrumbs = [
            ['link' => "/", 'name' => "Home"], ['link' => "javascript:void(0)", 'name' => "Forms"], ['name' => "Form Repeater"]
        ];
        return view('/content/forms/form-repeater', [
            'breadcrumbs' => $breadcrumbs
        ]);
    }*/
}
