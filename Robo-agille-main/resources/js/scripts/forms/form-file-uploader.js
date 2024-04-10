/*=========================================================================================
    File Name: form-file-uploader.js
    Description: dropzone
    --------------------------------------------------------------------------------------
    Item Name: Vuexy  - Vuejs, HTML & Laravel Admin Dashboard Template
    Author: PIXINVENT
    Author URL: http://www.themeforest.net/user/pixinvent
==========================================================================================*/

Dropzone.autoDiscover = false;

$(function () {
  'use strict';

  var singleFile = $('#dpz-single-file');
  var multipleFiles = $('#dpz-multiple-files');
  var imoveisFilesZip = $('#dpz-imoveis-files');
  var ditrFilesZip = $('#dpz-imoveis-files-dirt');
  var buttonSelect = $('#dpz-btn-select-files');
  var limitFiles = $('#dpz-file-limits');
  var acceptFiles = $('#dpz-accept-files');
  var removeThumb = $('#dpz-remove-thumb');
  var removeAllThumbs = $('#dpz-remove-all-thumb');

  // Basic example
  singleFile.dropzone({
    paramName: 'file', // The name that will be used to transfer the file
    maxFiles: 1
  });

   //AGILE IMOVEIS
  imoveisFilesZip.dropzone({
    paramName: "file", // Nome do parâmetro usado para enviar o arquivo
    maxFiles: 1, // Número máximo de arquivos permitidos
    maxFilesize: 10, // Tamanho máximo do arquivo em MB
    acceptedFiles: ".zip", // Tipos de arquivos permitidos
    dictDefaultMessage: "Arraste e solte um arquivo ZIP aqui ou clique para fazer upload",
    dictFileTooBig: "O arquivo é muito grande ({{filesize}} MB). Tamanho máximo permitido: {{maxFilesize}} MB.",
    dictInvalidFileType: "Tipo de arquivo inválido. Apenas arquivos ZIP são permitidos.",

    init: function() {
        var myDropzone = this;

        //Função de higiene de pasta (axios/clear)+ get retorna 0 para total de arquivos e pdfs
        axios.get('/imoveis-files/file/clear')
        .then(function(response) {
            console.log(JSON.stringify(response.data));
        }).catch(function(error) {
            // A pasta não existe ou ocorreu um erro
            console.log('Erro ao limpar', error);
        });




      // Callback chamado quando o upload é concluído com sucesso
      this.on("success", function(file, response) {
        console.log("Arquivo enviado com sucesso:", file.name);
        console.log("Resposta do servidor:", response);

        axios.get('/imoveis-files/file/dirname/')
        .then(function(response) {

            var dirUpName = response.data;
            console.log("teste" + typeof response.data[0]);
            var url = '/imoveis-files/file/count/'+ dirUpName;
            console.log(url);
            axios.get(url)
            .then(function(response) {
                // A pasta existe
                console.log("caminho da pasta"+ JSON.stringify(response.data));

                var totalArquivos = response.data.total_arquivos;
                var totalPDF = response.data.total_pdf;

                document.getElementById('totalArquivos').textContent = 1;
                document.getElementById('totalPdfs').textContent = totalPDF;

            })
            .catch(function(error) {
                // A pasta não existe ou ocorreu um erro
                console.log('A pasta não existe ou ocorreu um erro:', error);
            });


        })
        .catch(function(error) {
            // A pasta não existe ou ocorreu um erro
            console.log('Erro ao trazer nome do diretorio em Uncompress-File', error);
        });

        document.getElementById("upzip_ok").disabled = false;
        document.getElementById("confirm-text").disabled = false;
      });

      // Callback chamado quando ocorre um erro durante o upload
      this.on("error", function(file, errorMessage) {
        console.error("Erro ao enviar o arquivo:", file.name);
        console.error("Mensagem de erro:", errorMessage);
      });

      // Callback chamado quando um arquivo é adicionado à área de upload
      this.on("addedfile", function(file) {
        // Verifica se já existe um arquivo adicionado e remove-o
        if (myDropzone.files.length > 1) {
          myDropzone.removeFile(myDropzone.files[0]);
        }

        // Cria o botão de remoção
        var removeButton = Dropzone.createElement("<button class='btn btn-sm btn-danger'><i data-feather='trash-2'></i> Remover</button>");

        // Adiciona o botão de remoção acima do thumbnail
       // file.previewElement.insertBefore(file.previewElement.firstChild, removeButton);

        // Adiciona o evento de clique ao botão de remoção
        removeButton.addEventListener("click", function(e) {
          e.preventDefault();
          e.stopPropagation();

          // Remove o arquivo da área de upload
          myDropzone.removeFile(file);
        });
      });
    }
  });


  //AGILLE DIRT FILES
  ditrFilesZip.dropzone({
    paramName: "file", // Nome do parâmetro usado para enviar o arquivo
    maxFiles: 1, // Número máximo de arquivos permitidos
    maxFilesize: 10, // Tamanho máximo do arquivo em MB
    acceptedFiles: ".zip", // Tipos de arquivos permitidos
    dictDefaultMessage: "Arraste e solte um arquivo ZIP aqui ou clique para fazer upload",
    dictFileTooBig: "O arquivo é muito grande ({{filesize}} MB). Tamanho máximo permitido: {{maxFilesize}} MB.",
    dictInvalidFileType: "Tipo de arquivo inválido. Apenas arquivos ZIP são permitidos.",

    init: function() {
        var myDropzone = this;

        //Função de higiene de pasta (axios/clear)+ get retorna 0 para total de arquivos e pdfs
        axios.get('/ditr-files/file/clear')
        .then(function(response) {
            console.log(JSON.stringify(response.data));
        }).catch(function(error) {
            // A pasta não existe ou ocorreu um erro
            console.log('Erro ao limpar', error);
        });




      // Callback chamado quando o upload é concluído com sucesso
      this.on("success", function(file, response) {
        console.log("Arquivo enviado com sucesso:", file.name);
        console.log("Resposta do servidor:", response);

        axios.get('/ditr-files/file/dirname/')
        .then(function(response) {

            var dirUpName = response.data;
            console.log("teste" + typeof response.data[0]);
            var url = '/ditr-files/file/count/'+ dirUpName;
            console.log(url);
            axios.get(url)
            .then(function(response) {
                // A pasta existe
                console.log("caminho da pasta"+ JSON.stringify(response.data));

                var totalArquivos = response.data.total_arquivos;
                var totalPDF = response.data.total_pdf;

                document.getElementById('totalArquivos').textContent = 1;
                document.getElementById('totalPdfs').textContent = totalPDF;

            })
            .catch(function(error) {
                // A pasta não existe ou ocorreu um erro
                console.log('A pasta não existe ou ocorreu um erro:', error);
            });


        })
        .catch(function(error) {
            // A pasta não existe ou ocorreu um erro
            console.log('Erro ao trazer nome do diretorio em Uncompress-File', error);
        });

        document.getElementById("upzip_ok").disabled = false;
        document.getElementById("confirm-ditr").disabled = false;
      });

      // Callback chamado quando ocorre um erro durante o upload
      this.on("error", function(file, errorMessage) {
        console.error("Erro ao enviar o arquivo:", file.name);
        console.error("Mensagem de erro:", errorMessage);
      });

      // Callback chamado quando um arquivo é adicionado à área de upload
      this.on("addedfile", function(file) {
        // Verifica se já existe um arquivo adicionado e remove-o
        if (myDropzone.files.length > 1) {
          myDropzone.removeFile(myDropzone.files[0]);
        }

        // Cria o botão de remoção
        var removeButton = Dropzone.createElement("<button class='btn btn-sm btn-danger'><i data-feather='trash-2'></i> Remover</button>");

        // Adiciona o botão de remoção acima do thumbnail
       // file.previewElement.insertBefore(file.previewElement.firstChild, removeButton);

        // Adiciona o evento de clique ao botão de remoção
        removeButton.addEventListener("click", function(e) {
          e.preventDefault();
          e.stopPropagation();

          // Remove o arquivo da área de upload
          myDropzone.removeFile(file);
        });
      });
    }
  });

});
