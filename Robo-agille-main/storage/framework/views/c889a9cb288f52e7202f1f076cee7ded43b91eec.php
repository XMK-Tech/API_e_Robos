<?php
$configData = Helper::applClasses();
?>
<div class="main-menu menu-fixed <?php echo e($configData['theme'] === 'dark' || $configData['theme'] === 'semi-dark' ? 'menu-dark' : 'menu-light'); ?> menu-accordion menu-shadow" data-scroll-to-active="true">
    <div class="navbar-header">
        <ul class="nav navbar-nav flex-row">
            <li class="nav-item me-auto">
                <a class="navbar-brand" href="<?php echo e(url('/')); ?>">
                    <span class="brand-logo">
                    <img src="<?php echo e(asset('images/logo/logo.png')); ?>" alt="Logo">
                    </span>
                    <h2 class="brand-text">Magicfiles</h2>
                </a>
            </li>
            <li class="nav-item nav-toggle">
                <a class="nav-link modern-nav-toggle pe-0" data-toggle="collapse">
                    <i class="d-block d-xl-none text-primary toggle-icon font-medium-4" data-feather="x"></i>
                    <i class="d-none d-xl-block collapse-toggle-icon font-medium-4 text-primary" data-feather="disc" data-ticon="disc"></i>
                </a>
            </li>
        </ul>
    </div>
    <div class="shadow-bottom"></div>
    <div class="main-menu-content">
        <ul class="navigation navigation-main" id="main-menu-navigation" data-menu="menu-navigation">
            
            <?php if(isset($menuData[0])): ?>
            <?php $__currentLoopData = $menuData[0]->menu; $__env->addLoop($__currentLoopData); foreach($__currentLoopData as $menu): $__env->incrementLoopIndices(); $loop = $__env->getLastLoop(); ?>
            <?php if(isset($menu->navheader)): ?>
            <li class="navigation-header">
                <span><?php echo e(__('locale.' . $menu->navheader)); ?></span>
                <i data-feather="more-horizontal"></i>
            </li>
            <?php else: ?>
            
            <?php
            $custom_classes = '';
            if (isset($menu->classlist)) {
            $custom_classes = $menu->classlist;
            }
            ?>
            <li class="nav-item <?php echo e($custom_classes); ?> <?php echo e(Route::currentRouteName() === $menu->slug ? 'active' : ''); ?>">
                <a href="<?php echo e(isset($menu->url) ? url($menu->url) : 'javascript:void(0)'); ?>" class="d-flex align-items-center" target="<?php echo e(isset($menu->newTab) ? '_blank' : '_self'); ?>">
                    <i data-feather="<?php echo e($menu->icon); ?>"></i>
                    <span class="menu-title text-truncate"><?php echo e(__('locale.' . $menu->name)); ?></span>
                    <?php if(isset($menu->badge)): ?>
                    <?php $badgeClasses = 'badge rounded-pill badge-light-primary ms-auto me-1'; ?>
                    <span class="<?php echo e(isset($menu->badgeClass) ? $menu->badgeClass : $badgeClasses); ?>"><?php echo e($menu->badge); ?></span>
                    <?php endif; ?>
                </a>
                <?php if(isset($menu->submenu)): ?>
                <?php echo $__env->make('panels/submenu', ['menu' => $menu->submenu], \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?>
                <?php endif; ?>
            </li>
            <?php endif; ?>
            <?php endforeach; $__env->popLoop(); $loop = $__env->getLastLoop(); ?>
            <?php endif; ?>
            
        </ul>
    </div>
</div>
<!-- END: Main Menu-->
<?php /**PATH /home/u657453689/domains/minhaellementar.com.br/public_html/agille/entrega/resources/views/panels/sidebar.blade.php ENDPATH**/ ?>