<?php $__env->startSection('title', 'Bem vindo' ); ?>

<?php $__env->startSection('page-style'); ?>

<link rel="stylesheet" href="<?php echo e(asset(mix('css/base/plugins/forms/form-validation.css'))); ?>">
<link rel="stylesheet" href="<?php echo e(asset(mix('css/base/pages/authentication.css'))); ?>">
<?php $__env->stopSection(); ?>

<?php $__env->startSection('content'); ?>
<div class="auth-wrapper auth-basic px-2">
    <div class="auth-inner my-2">
        <!-- Login basic -->
        <h2 class="error" style="color:#ea5455; text-align: center;"><?php echo e($errors->has('login-password') ? $errors->first('login-password') : ''); ?></h2>
        <div class="card mb-0">
            <div class="card-body" style="text-align: center;">
                <a href="#" class="brand-logo">

                    <h2 class="brand-text text-primary ms-1">Agille</h2>
                </a>

                <h4 class="card-title mb-1">Bem vindo! 👋</h4>
                <div class="auth-footer-btn d-flex justify-content-center">
                    <a href="<?php echo e(route('dashboard-home')); ?>" class="btn btn-large btn-success">
                        <span>ENTRAR</span>
                    </a>
                </div>
                
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
<?php $__env->stopSection(); ?>

<?php $__env->startSection('vendor-script'); ?>
<script src="<?php echo e(asset(mix('vendors/js/forms/validation/jquery.validate.min.js'))); ?>"></script>
<?php $__env->stopSection(); ?>

<?php $__env->startSection('page-script'); ?>
<script src="<?php echo e(asset(mix('js/scripts/pages/auth-login.js'))); ?>"></script>
<?php $__env->stopSection(); ?>

<?php echo $__env->make('layouts/fullLayoutMaster', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/u657453689/domains/minhaellementar.com.br/public_html/agille/entrega/resources/views//content/authentication/auth-login-basic.blade.php ENDPATH**/ ?>