<?php $__env->startSection('title', 'Início'); ?>

<?php $__env->startSection('vendor-style'); ?>
  
  <link rel="stylesheet" href="<?php echo e(asset(mix('vendors/css/charts/apexcharts.css'))); ?>">
  <link rel="stylesheet" href="<?php echo e(asset(mix('vendors/css/extensions/toastr.min.css'))); ?>">
<?php $__env->stopSection(); ?>
<?php $__env->startSection('page-style'); ?>
  
  <link rel="stylesheet" href="<?php echo e(asset(mix('css/base/pages/dashboard-ecommerce.css'))); ?>">
  <link rel="stylesheet" href="<?php echo e(asset(mix('css/base/plugins/charts/chart-apex.css'))); ?>">
  <link rel="stylesheet" href="<?php echo e(asset(mix('css/base/plugins/extensions/ext-component-toastr.css'))); ?>">
<?php $__env->stopSection(); ?>

<?php $__env->startSection('content'); ?> 
<?php $__env->stopSection(); ?>

<?php $__env->startSection('vendor-script'); ?>
  
  <script src="<?php echo e(asset(mix('vendors/js/charts/apexcharts.min.js'))); ?>"></script>
  <script src="<?php echo e(asset(mix('vendors/js/extensions/toastr.min.js'))); ?>"></script>
<?php $__env->stopSection(); ?>
<?php $__env->startSection('page-script'); ?>
  
  <script src="<?php echo e(asset(mix('js/scripts/pages/dashboard-ecommerce.js'))); ?>"></script>
<?php $__env->stopSection(); ?>

<?php echo $__env->make('layouts/contentLayoutMaster', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/u657453689/domains/minhaellementar.com.br/public_html/agille/entrega/resources/views//content/dashboard/dashboard-ecommerce.blade.php ENDPATH**/ ?>