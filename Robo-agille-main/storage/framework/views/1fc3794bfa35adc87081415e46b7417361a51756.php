<!-- ALERTS Sweet Alert CSS-->
<link rel="stylesheet" href="<?php echo e(asset(mix('vendors/css/animate/animate.min.css'))); ?>">
<link rel="stylesheet" href="<?php echo e(asset(mix('vendors/css/extensions/sweetalert2.min.css'))); ?>">
<!-- END: Sweet Alert CSS-->
<!-- BEGIN: Vendor CSS-->
<?php if($configData['direction'] === 'rtl' && isset($configData['direction'])): ?>
<link rel="stylesheet" href="<?php echo e(asset(mix('vendors/css/vendors-rtl.min.css'))); ?>" />
<?php else: ?>
<link rel="stylesheet" href="<?php echo e(asset(mix('vendors/css/vendors.min.css'))); ?>" />
<?php endif; ?>

<?php echo $__env->yieldContent('vendor-style'); ?>
<!-- END: Vendor CSS-->

<!-- BEGIN: Theme CSS-->
<link rel="stylesheet" href="<?php echo e(asset(mix('css/core.css'))); ?>" />
<link rel="stylesheet" href="<?php echo e(asset(mix('css/base/themes/dark-layout.css'))); ?>" />
<link rel="stylesheet" href="<?php echo e(asset(mix('css/base/themes/bordered-layout.css'))); ?>" />
<link rel="stylesheet" href="<?php echo e(asset(mix('css/base/themes/semi-dark-layout.css'))); ?>" />

<?php $configData = Helper::applClasses(); ?>

<!-- BEGIN: Page CSS-->
<?php if($configData['mainLayoutType'] === 'horizontal'): ?>
<link rel="stylesheet" href="<?php echo e(asset(mix('css/base/core/menu/menu-types/horizontal-menu.css'))); ?>" />
<?php else: ?>
<link rel="stylesheet" href="<?php echo e(asset(mix('css/base/core/menu/menu-types/vertical-menu.css'))); ?>" />
<?php endif; ?>


<?php echo $__env->yieldContent('page-style'); ?>

<!-- laravel style -->
<link rel="stylesheet" href="<?php echo e(asset(mix('css/overrides.css'))); ?>" />

<!-- BEGIN: Custom CSS-->
<link rel="stylesheet" href="<?php echo e(asset(mix('css/base/plugins/extensions/ext-component-sweet-alerts.css'))); ?>">
<?php if($configData['direction'] === 'rtl' && isset($configData['direction'])): ?>
<link rel="stylesheet" href="<?php echo e(asset(mix('css-rtl/custom-rtl.css'))); ?>" />
<link rel="stylesheet" href="<?php echo e(asset(mix('css-rtl/style-rtl.css'))); ?>" />

<?php else: ?>

<link rel="stylesheet" href="<?php echo e(asset(mix('css/style.css'))); ?>" />
<?php endif; ?>
<?php /**PATH /home/u657453689/domains/minhaellementar.com.br/public_html/agille/entrega/resources/views/panels/styles.blade.php ENDPATH**/ ?>