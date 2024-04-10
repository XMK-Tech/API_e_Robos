@extends('layouts/fullLayoutMaster')

@section('title', 'Bem vindo' )

@section('page-style')
{{-- Page Css files --}}
<link rel="stylesheet" href="{{ asset(mix('css/base/plugins/forms/form-validation.css')) }}">
<link rel="stylesheet" href="{{ asset(mix('css/base/pages/authentication.css')) }}">
@endsection

@section('content')
<div class="auth-wrapper auth-basic px-2">
    <div class="auth-inner my-2">
        <!-- Login basic -->
        <h2 class="error" style="color:#ea5455; text-align: center;">{{ $errors->has('login-password') ? $errors->first('login-password') : '' }}</h2>
        <div class="card mb-0">
            <div class="card-body" style="text-align: center;">
                <a href="#" class="brand-logo">

                    <h2 class="brand-text text-primary ms-1">Agille</h2>
                </a>

                <h4 class="card-title mb-1">Bem vindo! 👋</h4>
                <div class="auth-footer-btn d-flex justify-content-center">
                    <a href="{{ route('dashboard-home') }}" class="btn btn-large btn-success">
                        <span>ENTRAR</span>
                    </a>
                </div>
                {{--
                <form class="auth-login-form mt-2" action="{{ route('login-basic')}}" method="POST">
                    @csrf
                    <div class="mb-1">
                        <label for="login-email" class="form-label">Email</label>
                        <input type="text" class="form-control" id="login-email" name="login-email" placeholder="john@example.com" aria-describedby="login-email" value="{{ old('login-email') }}" tabindex="1" autofocus />
                    </div>

                    <div class="mb-1">
                        <div class="d-flex justify-content-between">
                            <label class="form-label" for="login-password">Password</label>
                            <a href="{{url('auth/forgot-password-basic')}}">
                            <small>Forgot Password?</small>
                            </a>
                        </div>
                        <div class="input-group input-group-merge form-password-toggle">
                            <input type="password" class="form-control form-control-merge" id="login-password" name="login-password" tabindex="2" placeholder="&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;&#xb7;" value="{{ old('login-password') }}" aria-describedby="login-password" />
                            <span class="input-group-text cursor-pointer"><i data-feather="eye"></i></span>
                        </div>
                    </div>
                    <div class="mb-1">
                        <div class="form-check">
                            <input class="form-check-input" type="checkbox" id="remember-me" tabindex="3" />
                            <label class="form-check-label" for="remember-me"> Remember Me </label>
                        </div>
                    </div>
                    <button class="btn btn-success w-100" tabindex="4">Entrar</button>
                </form>
                --}}
                <p class="text-center mt-2">

                    <span>Precisa de ajuda, então fale conosco ?</span>
                    <a href="https://api.whatsapp.com/send?phone=5541999128549&text=Ol%C3%A1,%20estou%20com%20uma%20d%C3%BAvida,%20pode%20me%20ajudar!">
                <br>
                    <span>Abrir WhatsApp</span>
                </a>
                </p>

                <div class="divider my-2">
                    <div class="divider-text">saiba mais sobre nós</div>
                </div>

                <div class="auth-footer-btn d-flex justify-content-center">
                    <a href="https://ellementar.com.br" class="btn btn-twitter">
                        <span>Ellementar Technology</span>
                    </a>
                </div>
            </div>
        </div>
        <!-- /Login basic -->
    </div>
</div>
@endsection

@section('vendor-script')
<script src="{{asset(mix('vendors/js/forms/validation/jquery.validate.min.js'))}}"></script>
@endsection

@section('page-script')
<script src="{{asset(mix('js/scripts/pages/auth-login.js'))}}"></script>
@endsection
