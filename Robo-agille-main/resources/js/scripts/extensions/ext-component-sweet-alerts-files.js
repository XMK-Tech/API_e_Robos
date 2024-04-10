$(function () {
    'use strict';


    var confirmText = $('#confirm-text');
    var confirmDirt = $('#confirm-ditr');


    var assetPath = '../../../app-assets/';
    if ($('body').attr('data-framework') === 'laravel') {
        assetPath = $('body').attr('data-asset-path');
    }


    //--------------- Confirm Options ---------------

    // PDF IMOVEIS
    if (confirmText.length) {
        confirmText.on('click', function () {
            Swal.fire({
                title: 'Ésta ação pode demorar!',
                text: "Desenja continuar!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sim',
                cancelButtonText: 'Não',
                customClass: {
                    confirmButton: 'btn btn-primary btn-next',
                    cancelButton: 'btn btn-outline-danger ms-1'
                },
                buttonsStyling: false
            }).then(function (result) {
                const personalInfoTrigger = document.getElementById('personal-info-modern-trigger');
                personalInfoTrigger.classList.remove('active');
                personalInfoTrigger.classList.add('crossed');

                // Remover as propriedades "active" e "dstepper-block" de uma série de elementos com a classe "dstepper-block"
                const dstepperBlocks = document.querySelectorAll('.dstepper-block');
                dstepperBlocks.forEach((element) => {
                element.classList.remove('active', 'dstepper-block');
                });

                // Atribuir a propriedade "active" à classe do elemento com id "social-links-modern-trigger"
                const socialLinksTrigger = document.getElementById('social-links-modern-trigger');
                socialLinksTrigger.classList.add('active');

                // Atribuir a propriedade "active dstepper-block" à classe do elemento com id "social-links-modern"
                const personalInfoElement = document.getElementById('social-links-modern');
                personalInfoElement.classList.add('active', 'dstepper-block');
                if (result.value) {

                   axios.get('/imoveis-files/file/dirname/')
                   .then(function(response) {

                        var dirUpName = response.data;
                        console.log("nome no diretorio" + dirUpName);

                        // Substituir o conteúdo da div com id "center-result"
                        var centerResultDiv = document.getElementById('center-result');
                        centerResultDiv.innerHTML = `
                        <span class="badge bg-light-primary p-75 rounded">
                          <img src="/images/icons/zip.png" alt="file-icon" height="35" />
                        </span>
                        <div class="ms-75">
                          <h4 class="mb-0"><span id="nomeZip">${dirUpName}</span></h4>
                          <small class="text-success">Você gerou seu arquivo .ZIP com sucesso.</small>
                        </div>

                      `;
                      document.getElementById("btnDownload").disabled = false;
                        axios.get('/imoveis-files/process/'+ dirUpName)
                            .then(function(response) {

                                document.getElementById("btnDownload").addEventListener("click", function() {
                                    // Exibir spinner
                                    this.innerHTML = `<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Aguarde...`;

                                    // Desabilitar o botão
                                    this.disabled = true;

                                    // URL do arquivo a ser baixado
                                    var fileUrl = `/uncompress-files/imoveis/${dirUpName}/${dirUpName}.zip`;

                                    // Criar um elemento <a> temporário
                                    var link = document.createElement("a");
                                    link.href = fileUrl;
                                    link.target = "_blank";
                                    link.download = fileUrl.substr(fileUrl.lastIndexOf("/") + 1);

                                    // Disparar o evento de clique no elemento <a> temporário após 10 segundos
                                    setTimeout(function() {
                                      // Remover o spinner
                                      document.getElementById("btnDownload").innerHTML = `<svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-download align-middle me-sm-25 me-0"><path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"></path><polyline points="7 10 12 15 17 10"></polyline><line x1="12" y1="15" x2="12" y2="3"></line></svg> <span class="align-middle d-sm-inline-block"> Baixar ZIP</span>`;

                                      // Habilitar o botão
                                      document.getElementById("btnDownload").disabled = false;

                                      // Disparar o evento de clique
                                      var event = new MouseEvent("click", {
                                        view: window,
                                        bubbles: true,
                                        cancelable: true
                                      });
                                      link.dispatchEvent(event);
                                    }, 5000);
                                  });

                            }).catch(function(error){
                                    console.log('Erro ao processar os arquivos da pasta',error);
                            })

                   }).catch(function(error){
                    var centerResultDiv = document.getElementById('center-result');
                        centerResultDiv.innerHTML = `
                        <span class="badge bg-light-primary p-75 rounded">
                          <img src="/images/icons/zip.png" alt="file-icon" height="35" />
                        </span>
                        <div class="ms-75">
                          <h4 class="mb-0"><span id="nomeZip">${dirUpName}</span></h4>
                          <small class="text-danger">Falha ao preocessar arquivos.</small>
                        </div>

                      `;
                        console.log('Ao processar a pasta não foi encontrada',error);
                   });
                }
            });
        });
    }


    // ARQUIVOS DIRT
    if (confirmDirt.length) {
        confirmDirt.on('click', function () {
            Swal.fire({
                title: 'Ésta ação pode demorar!',
                text: "Desenja continuar!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonText: 'Sim',
                cancelButtonText: 'Não',
                customClass: {
                    confirmButton: 'btn btn-primary btn-next',
                    cancelButton: 'btn btn-outline-danger ms-1'
                },
                buttonsStyling: false
            }).then(function (result) {
                const personalInfoTrigger = document.getElementById('personal-info-modern-trigger');
                personalInfoTrigger.classList.remove('active');
                personalInfoTrigger.classList.add('crossed');

                // Remover as propriedades "active" e "dstepper-block" de uma série de elementos com a classe "dstepper-block"
                const dstepperBlocks = document.querySelectorAll('.dstepper-block');
                dstepperBlocks.forEach((element) => {
                element.classList.remove('active', 'dstepper-block');
                });

                // Atribuir a propriedade "active" à classe do elemento com id "social-links-modern-trigger"
                const socialLinksTrigger = document.getElementById('social-links-modern-trigger');
                socialLinksTrigger.classList.add('active');

                // Atribuir a propriedade "active dstepper-block" à classe do elemento com id "social-links-modern"
                const personalInfoElement = document.getElementById('social-links-modern');
                personalInfoElement.classList.add('active', 'dstepper-block');
                if (result.value) {

                   axios.get('/ditr-files/file/dirname/')
                   .then(function(response) {

                        var dirUpName = response.data;
                        console.log("nome no diretorio" + dirUpName);

                        // Substituir o conteúdo da div com id "center-result"
                        var centerResultDiv = document.getElementById('center-result');
                        centerResultDiv.innerHTML = `
                        <span class="badge bg-light-primary p-75 rounded">
                          <img src="/images/icons/zip.png" alt="file-icon" height="35" />
                        </span>
                        <div class="ms-75">
                          <h4 class="mb-0"><span id="nomeZip">${dirUpName}</span></h4>
                          <small class="text-success">Você gerou seu arquivo .ZIP com sucesso.</small>
                        </div>

                      `;
                      document.getElementById("btnDownload").disabled = false;
                        axios.get('/ditr-files/process/'+ dirUpName)
                            .then(function(response) {

                                document.getElementById("btnDownload").addEventListener("click", function() {
                                    // Exibir spinner
                                    this.innerHTML = `<span class="spinner-border spinner-border-sm" role="status" aria-hidden="true"></span> Aguarde...`;

                                    // Desabilitar o botão
                                    this.disabled = true;

                                    // URL do arquivo a ser baixado
                                    var fileUrl = `/uncompress-files/ditr/${dirUpName}/${dirUpName}.zip`;

                                    // Criar um elemento <a> temporário
                                    var link = document.createElement("a");
                                    link.href = fileUrl;
                                    link.target = "_blank";
                                    link.download = fileUrl.substr(fileUrl.lastIndexOf("/") + 1);

                                    // Disparar o evento de clique no elemento <a> temporário após 10 segundos
                                    setTimeout(function() {
                                      // Remover o spinner
                                      document.getElementById("btnDownload").innerHTML = `<svg xmlns="http://www.w3.org/2000/svg" width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-download align-middle me-sm-25 me-0"><path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4"></path><polyline points="7 10 12 15 17 10"></polyline><line x1="12" y1="15" x2="12" y2="3"></line></svg> <span class="align-middle d-sm-inline-block"> Baixar ZIP</span>`;

                                      // Habilitar o botão
                                      document.getElementById("btnDownload").disabled = false;

                                      // Disparar o evento de clique
                                      var event = new MouseEvent("click", {
                                        view: window,
                                        bubbles: true,
                                        cancelable: true
                                      });
                                      link.dispatchEvent(event);
                                    }, 5000);
                                  });

                            }).catch(function(error){
                                    console.log('Erro ao processar os arquivos da pasta',error);
                            })

                   }).catch(function(error){
                    var centerResultDiv = document.getElementById('center-result');
                        centerResultDiv.innerHTML = `
                        <span class="badge bg-light-primary p-75 rounded">
                          <img src="/images/icons/zip.png" alt="file-icon" height="35" />
                        </span>
                        <div class="ms-75">
                          <h4 class="mb-0"><span id="nomeZip">${dirUpName}</span></h4>
                          <small class="text-danger">Falha ao preocessar arquivos.</small>
                        </div>

                      `;
                        console.log('Ao processar a pasta não foi encontrada',error);
                   });
                }
            });
        });
    }
});
