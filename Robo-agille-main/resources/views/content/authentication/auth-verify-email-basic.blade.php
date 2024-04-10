@extends('layouts/fullLayoutMaster')

@section('title', 'Verify Email Basic')

@section('page-style')
  <link rel="stylesheet" href="{{ asset(mix('css/base/pages/authentication.css')) }}">
@endsection

@section('content')
<div class="auth-wrapper auth-basic px-2">
  <div class="auth-inner my-2">
    <!-- verify email basic -->
    <div class="card mb-0">
      <div class="card-body">
        <a href="{{ url('/') }}" class="brand-logo">
            <img src="{{ asset('images/logo/logo.png') }}" alt="Logo">
          <h2 class="brand-text text-primary ms-1">Magicfiles</h2>
        </a>

        <h2 class="card-title fw-bolder mb-1">Verify your email ✉️</h2>
        <p class="card-text mb-2">
          We've sent a link to your email address: <span class="fw-bolder">hello@pixinvent.com</span> Please follow the
          link inside to continue.
        </p>

        <a href="{{asset('/')}}" class="btn btn-primary w-100">Skip for now</a>

        <p class="text-center mt-2">
          <span>Didn't receive an email? </span><a href="Javascript:void(0)"><span>&nbsp;Resend</span></a>
        </p>
      </div>
    </div>
    <!-- / verify email basic -->
  </div>
</div>
@endsection
