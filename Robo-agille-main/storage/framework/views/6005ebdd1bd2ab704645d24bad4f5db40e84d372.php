<!-- BEGIN: Vendor JS-->
<script src="<?php echo e(asset(mix('vendors/js/vendors.min.js'))); ?>"></script>
<script src="<?php echo e(asset(mix('vendors/js/extensions/sweetalert2.all.min.js'))); ?>"></script>
<script src="<?php echo e(asset(mix('vendors/js/extensions/polyfill.min.js'))); ?>"></script>
<!-- END: Page JS-->

<!-- BEGIN Vendor JS-->
<!-- BEGIN: Page Vendor JS-->
<script src="<?php echo e(asset(mix('vendors/js/ui/jquery.sticky.js'))); ?>"></script>
<?php echo $__env->yieldContent('vendor-script'); ?>
<!-- END: Page Vendor JS-->
<!-- BEGIN: Theme JS-->
<script src="<?php echo e(asset(mix('js/core/app-menu.js'))); ?>"></script>
<script src="<?php echo e(asset(mix('js/core/app.js'))); ?>"></script>

<!-- custome scripts file for user -->
<script src="<?php echo e(asset(mix('js/core/scripts.js'))); ?>"></script>

<?php if($configData['blankPage'] === false): ?>
<script src="<?php echo e(asset(mix('js/scripts/customizer.js'))); ?>"></script>
<?php endif; ?>
<!-- END: Theme JS-->
<!-- BEGIN: Page JS-->
<?php echo $__env->yieldContent('page-script'); ?>

<!-- END: Page JS-->
<?php /**PATH /home/u657453689/domains/minhaellementar.com.br/public_html/agille/entrega/resources/views/panels/scripts.blade.php ENDPATH**/ ?>