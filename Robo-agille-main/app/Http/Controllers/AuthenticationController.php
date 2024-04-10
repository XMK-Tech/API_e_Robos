<?php

namespace App\Http\Controllers;

use Dotenv\Validator;
use Illuminate\Support\Facades\Auth;
use Illuminate\Http\Request;
use App\Models\User;


class AuthenticationController extends Controller
{
    public function __construct()
    {
    }
    public function index()
    {
        $pageConfigs = ['blankPage' => true];
        return view('/content/authentication/auth-login-basic', compact('pageConfigs'));
    }
    // Login basic
    public function login_basic(Request $request)
    {
        $pageConfigs = ['blankPage' => true];

        $erro = $request->get('erro');

        //REGRAS DE PREENCHIMENTO
        $regras = [
            'login-email' =>    'email',
            'login-password' => 'required'
        ];

        $feedback = [
            'login-email.email' =>    'Usuário inválido!',
            'login-password.required' => 'Usuário inválido!'
        ];
        $request->validate($regras, $feedback);
        //echo 'teste validate';

        $email = $request->get('login-email');
        $password = $request->get('login-password');

        $user = new User();
        $usuario = $user->where('email', $email)->where('password', $password)->get()->first();

        if (isset($usuario->name)) {

            $pageConfigs = ['blankPage' => false];
            $pageConfigs = ['pageHeader' => false];
            $validadion = ['validadtion' => 1];
            $data_user = ['nome' => 'Newport'];


            session_start();
            $_SESSION['nome'] = $usuario->name;
            $_SESSION['email'] = $usuario->email;
            //dd($_SESSION);

            // USUÁRIO AUTENTICADO COM USER DATA CARREGADO
            return redirect()->route('dashboard-home');
            //    return view('/content/dashboard/dashboard-ecommerce', compact('pageConfigs', 'validadion', 'data_user'));
        } else {
            $request->validate($regras, $feedback);
            return redirect()->route('login-basic', ['erro' => 1]);
        }
    }

    // Login Cover
    public function login_cover()
    {
        $pageConfigs = ['blankPage' => true];

        return view('/content/authentication/auth-login-cover', ['pageConfigs' => $pageConfigs]);
    }

    // Register basic
    public function register_basic()
    {
        $pageConfigs = ['blankPage' => true];

        return view('/content/authentication/auth-register-basic', ['pageConfigs' => $pageConfigs]);
    }

    // Register cover
    public function register_cover()
    {
        $pageConfigs = ['blankPage' => true];

        return view('/content/authentication/auth-register-cover', ['pageConfigs' => $pageConfigs]);
    }

    // Forgot Password basic
    public function forgot_password_basic()
    {
        $pageConfigs = ['blankPage' => true];

        return view('/content/authentication/auth-forgot-password-basic', ['pageConfigs' => $pageConfigs]);
    }

    // Forgot Password cover
    public function forgot_password_cover()
    {
        $pageConfigs = ['blankPage' => true];

        return view('/content/authentication/auth-forgot-password-cover', ['pageConfigs' => $pageConfigs]);
    }

    // Reset Password basic
    public function reset_password_basic()
    {
        $pageConfigs = ['blankPage' => true];

        return view('/content/authentication/auth-reset-password-basic', ['pageConfigs' => $pageConfigs]);
    }

    // Reset Password cover
    public function reset_password_cover()
    {
        $pageConfigs = ['blankPage' => true];

        return view('/content/authentication/auth-reset-password-cover', ['pageConfigs' => $pageConfigs]);
    }

    // email verify basic
    public function verify_email_basic()
    {
        $pageConfigs = ['blankPage' => true];

        return view('/content/authentication/auth-verify-email-basic', ['pageConfigs' => $pageConfigs]);
    }

    // email verify cover
    public function verify_email_cover()
    {
        $pageConfigs = ['blankPage' => true];

        return view('/content/authentication/auth-verify-email-cover', ['pageConfigs' => $pageConfigs]);
    }

    // two steps basic
    public function two_steps_basic()
    {
        $pageConfigs = ['blankPage' => true];

        return view('/content/authentication/auth-two-steps-basic', ['pageConfigs' => $pageConfigs]);
    }

    // two steps cover
    public function two_steps_cover()
    {
        $pageConfigs = ['blankPage' => true];

        return view('/content/authentication/auth-two-steps-cover', ['pageConfigs' => $pageConfigs]);
    }

    // register multi steps
    public function register_multi_steps()
    {
        $pageConfigs = ['blankPage' => true];

        return view('/content/authentication/auth-register-multisteps', ['pageConfigs' => $pageConfigs]);
    }
}
