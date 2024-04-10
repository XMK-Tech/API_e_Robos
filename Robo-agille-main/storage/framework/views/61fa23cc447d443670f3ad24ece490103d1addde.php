<?php $__env->startSection('title', 'PDF Imóveis'); ?>

<?php $__env->startSection('vendor-style'); ?>
  <!-- vendor css files -->
  <script src="https://cdn.jsdelivr.net/npm/axios/dist/axios.min.js"></script>
  <link rel="stylesheet" href="<?php echo e(asset(mix('vendors/css/file-uploaders/dropzone.min.css'))); ?>">
  <link rel="stylesheet" href="<?php echo e(asset(mix('vendors/css/forms/wizard/bs-stepper.min.css'))); ?>">
  <link rel="stylesheet" href="<?php echo e(asset(mix('vendors/css/forms/select/select2.min.css'))); ?>">
  <link rel="stylesheet" href="<?php echo e(asset(mix('vendors/css/animate/animate.min.css'))); ?>">
  <link rel="stylesheet" href="<?php echo e(asset(mix('vendors/css/extensions/sweetalert2.min.css'))); ?>">

<?php $__env->stopSection(); ?>
<?php $__env->startSection('page-style'); ?>
  <!-- Page css files -->
  <link rel="stylesheet" href="<?php echo e(asset(mix('css/base/plugins/forms/form-file-uploader.css'))); ?>">
  <link rel="stylesheet" href="<?php echo e(asset(mix('css/base/plugins/forms/form-validation.css'))); ?>">
  <link rel="stylesheet" href="<?php echo e(asset(mix('css/base/plugins/forms/form-wizard.css'))); ?>">
<?php $__env->stopSection(); ?>

<?php $__env->startSection('content'); ?>
<!-- Dropzone section start -->
<section id="dropzone-examples">

<!-- Modern Horizontal Wizard -->
<section class="modern-horizontal-wizard">
  <div class="bs-stepper wizard-modern modern-wizard-example">
    <div class="bs-stepper-header">
      <div class="step" data-target="#account-details-modern" role="tab" id="account-details-modern-trigger">
        <button type="button" class="step-trigger">
          <span class="bs-stepper-box">
            <i data-feather="file-text" class="font-medium-3"></i>
          </span>
          <span class="bs-stepper-label">
            <span class="bs-stepper-title">Adicione seus arquivos</span>
            <span class="bs-stepper-subtitle">Obrigatoriamente precisam ser .zip.</span>
          </span>
        </button>
      </div>
      <div class="line">
        <i data-feather="chevron-right" class="font-medium-2"></i>
      </div>
      <div class="step" data-target="#personal-info-modern" role="tab" id="personal-info-modern-trigger">
        <button type="button" class="step-trigger">
          <span class="bs-stepper-box">
            <i data-feather="file-text" class="font-medium-3"></i>
          </span>
          <span class="bs-stepper-label">
            <span class="bs-stepper-title">Validação de arquivos</span>
            <span class="bs-stepper-subtitle">Verifique os arquivos</span>
          </span>
        </button>
      </div>
      <div class="line">
        <i data-feather="chevron-right" class="font-medium-2"></i>
      </div>
      <div class="step" data-target="#social-links-modern" role="tab" id="social-links-modern-trigger">
        <button type="button" class="step-trigger">
          <span class="bs-stepper-box">
            <i data-feather='download' class="font-medium-3"></i>
            <i ></i>
          </span>
          <span class="bs-stepper-label">
            <span class="bs-stepper-title">ZIP para download</span>
            <span class="bs-stepper-subtitle">Baixe seu ZIP processado</span>
          </span>
        </button>
      </div>
    </div>
    <div class="bs-stepper-content">
      <div id="account-details-modern" class="content" role="tabpanel" aria-labelledby="account-details-modern-trigger">
        <!-- multi file upload starts -->
        <div class="row">
            <div class="col-12">
                <div class="card-body">
                <p class="card-text">
                    Arraste seus arquivos ao centro da área demarcada, somados seus arquivos devem ter, até 10Mb em arquivos do tipo ".zip".

                </p>
                <form action="/import-pdf-imoveis" method="POST" class="dropzone dropzone-area" id="dpz-imoveis-files" enctype="multipart/form-data">
                <?php echo csrf_field(); ?>
                    <div class="dz-message">Arraste o arquivo ZIP, para fazer o upload.</div>
                </form>
                </div>

            </div>
        </div>
        <!-- multi file upload ends -->
        <div class="d-flex justify-content-between">
          <div class="" disabled>


          </div>
          <button class="btn btn-primary btn-next" id="upzip_ok" disabled>
            <span class="align-middle d-sm-inline-block d-none" >Avançar</span>
            <i data-feather="arrow-right" class="align-middle ms-sm-25 ms-0"></i>
          </button>
        </div>
      </div>
      <div id="personal-info-modern" class="content" role="tabpanel" aria-labelledby="personal-info-modern-trigger">
        <div class="row">
            <div class="col-12">
                <div class="card-body">
                    <div class="card-text">
                        <p>Confira se o número de arquivos do tipo PDF são os mesmos que você comprimil no ZIP. Para continuar clique avançar.</p>
                    </div>
                    <div class="d-flex justify-content-around my-3 p-5" style="background: #f8f8f8;">
                        <div class="d-flex align-items-start me-2">
                            <span class="badge bg-light-primary p-75 rounded">
                            <img src="<?php echo e(asset('images/icons/zip.png')); ?>" alt="file-icon" height="35" />
                            </span>
                            <div class="ms-75">
                                <h4 class="mb-0"><span id="totalArquivos">0</span></h4>
                                <small>Total de arquivos .ZIP</small>
                            </div>
                        </div>
                        <div class="d-flex align-items-start">
                            <span class="badge bg-light-primary p-75 rounded">
                            <img src="<?php echo e(asset('images/icons/pdf.png')); ?>" alt="file-icon" height="35" />
                            </span>
                            <div class="ms-75">
                                <h4 class="mb-0"><span id="totalPdfs">0</span></h4>
                                <small>Arquivos do tipo .PDF</small>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="d-flex justify-content-between">
          <button class="btn btn-primary btn-prev">
            <i data-feather="arrow-left" class="align-middle me-sm-25 me-0"></i>
            <span class="align-middle d-sm-inline-block d-none">Voltar</span>
          </button>
          <button class="btn btn-success" id="confirm-text" disabled>
            <span class="align-middle d-sm-inline-block d-none" >Processar</span>
            <i data-feather="arrow-right" class="align-middle ms-sm-25 ms-0"></i>
            </button>
        </div>
      </div>
      <div id="social-links-modern" class="content" role="tabpanel" aria-labelledby="social-links-modern-trigger">
        <div class="row">
            <div class="col-12">
                <div class="card-body">
                    <div class="card-text">
                        <p>Baixer seu arquivo ZIP que possui o resultado do processamento, nele você irá encontrar 2 CSVs para cada PDF Imóveis processados.</p>
                    </div>
                    <div class="d-flex justify-content-around my-3 p-5" style="background: #f8f8f8;">
                        <div class="d-flex align-items-start me-2" id="center-result">
                            <div class="ms-75">
                                <h4 class="mb-0"><span id="nomeZip">-</span></h4>
                                <small>Não existem arquivos do tipo .ZIP</small>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="d-flex justify-content-between">
          <button class="btn btn-primary btn-prev">
            <i data-feather="arrow-left" class="align-middle me-sm-25 me-0"></i>
            <span class="align-middle d-sm-inline-block d-none">Voltar</span>
          </button>
          <button class="btn btn-success" id="btnDownload" disabled>
            <i data-feather="download" class="align-middle me-sm-25 me-0"></i>
            <span class="align-middle d-sm-inline-block"> Baixar ZIP</span>
        </button>
          <a href="imoveis-file-uploader" class="btn btn-info"><i data-feather='refresh-cw' class="align-middle me-sm-25 me-0"></i> Reiniciar</a>
        </div>
      </div>
    </div>
  </div>
</section>
</section>

<?php $__env->stopSection(); ?>

<?php $__env->startSection('vendor-script'); ?>
  <!-- vendor files -->
  <script src="<?php echo e(asset(mix('vendors/js/forms/wizard/bs-stepper.min.js'))); ?>"></script>
  <script src="<?php echo e(asset(mix('vendors/js/forms/select/select2.full.min.js'))); ?>"></script>
  <script src="<?php echo e(asset(mix('vendors/js/forms/validation/jquery.validate.min.js'))); ?>"></script>

  <script src="<?php echo e(asset(mix('vendors/js/file-uploaders/dropzone.min.js'))); ?>"></script>
  <!-- <script src="<?php echo e(asset(mix('vendors/js/extensions/sweetalert2.all.min.js'))); ?>"></script> -->

<?php $__env->stopSection(); ?>
<?php $__env->startSection('page-script'); ?>
  <!-- Page js files -->
  <script src="<?php echo e(asset(mix('js/scripts/forms/form-wizard.js'))); ?>"></script>
  <script src="<?php echo e(asset(mix('js/scripts/forms/form-file-uploader.js'))); ?>"></script>

  <script src="<?php echo e(asset(mix('js/scripts/extensions/ext-component-sweet-alerts-files.js'))); ?>"></script>

<?php $__env->stopSection(); ?>

<?php echo $__env->make('layouts/contentLayoutMaster', \Illuminate\Support\Arr::except(get_defined_vars(), ['__data', '__path']))->render(); ?><?php /**PATH /home/u657453689/domains/minhaellementar.com.br/public_html/agille/entrega/resources/views//content/converters/imoveis/imoveis-file-uploader.blade.php ENDPATH**/ ?>