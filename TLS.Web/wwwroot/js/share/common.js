﻿const roxyFileBrowser = function (callback, value, meta) {
    var roxyFileman = '/assets/plugins/custom/Roxy_Fileman/index.html';
    if (roxyFileman.indexOf("?") < 0) {
        roxyFileman += "?type=" + meta.filetype;
    }
    else {
        roxyFileman += "&type=" + meta.filetype;
    }
    //roxyFileman += '&input=' + fieldName + '&value=' + value;
    roxyFileman += '&value=' + value;

    if (tinyMCE.activeEditor.settings.language) {
        roxyFileman += '&langCode=' + tinyMCE.activeEditor.settings.language;
    }

    tinyMCE.activeEditor.windowManager.openUrl({
        title: 'Roxy Fileman',
        url: roxyFileman,
        width: 850,
        height: 650,
        onMessage: function (dialogApi, details) {
            callback(details.content);
            dialogApi.close();
        }
    });

    return false;
};

const initTinymce = function (selector) {
    tinymce.init({
        selector: selector,
        width: '100%',
        plugins: [
            'advlist autolink lists link image charmap print preview hr anchor pagebreak',
            'searchreplace wordcount visualblocks visualchars code fullscreen',
            'insertdatetime media nonbreaking save table contextmenu directionality',
            'emoticons template paste textcolor colorpicker textpattern imagetools codesample toc',
            'formula'
        ],
        toolbar: 'fullscreen',
        toolbar1:
            'undo redo | insert | fontsizeselect | fontselect | styleselect | bold italic | alignleft aligncenter alignright alignjustify | superscript subscript |bullist numlist outdent indent | link image ',
        toolbar2: 'print preview media | forecolor backcolor emoticons | codesample | formula',
        image_advtab: true,
        //"relative_urls" required by jbimages plugin to be set to "false"
        relative_urls: false,
        convert_urls: false,
        custom_elements: 'ins',
        extended_valid_elements: 'ins[*],iframe[*]',
        style_formats_merge: true,
        paste_data_images: true,
        fontsize_formats: "8pt 10pt 12pt 14pt 18pt 24pt 36pt",
        style_formats: [
            { title: 'High light', inline: 'span', classes: 'news-high-light-text' },
            { title: 'Table', classes: 'news-table', selector: 'table' },
            { title: 'Link button', selector: 'a', classes: 'news-link-button' },
        ],
        content_css: [
            'https://fonts.googleapis.com/css?family=Roboto'
        ],
        file_picker_callback: roxyFileBrowser,
        setup: function (editor) {
            editor.ui.registry.addContextToolbar('imgformula', {
                predicate: function (node) {
                    return node.nodeName.toLowerCase() === 'img' && $(node).prop("class") === "fm-editor-equation";
                },
                items: 'formula',
                position: 'node',
                scope: 'node'
            });
           
        }
    })
}

function openCropImageModal(e,aspectratio) {
    e.preventDefault()
    var cropImageModal = new bootstrap.Modal($('#cropper-img-modal'), {
        keyboard: false
    })
    cropImageModal.show();
    $("#upload-img").attr('src', null);
    $('#image-title-input').val('');
    $('#uploadFileImageInput').val('');
    $('.cropper-container').hide();
    // init croper
    cropper = new Cropper($("#upload-img")[0], {
        aspectRatio: aspectratio,
        autoCropArea: 0,
        zoomable: false
    });
}

function getCropImge(croppedImage,cropImagePreviewSelector) {
    if ($("#upload-img").attr('src') == null) {
        alert('Bạn chưa tải ảnh lên')
        return;
    }
    var canvas = cropper.getCroppedCanvas();
    canvas.toBlob(function (blob) {
        croppedImage.fileData = new File([blob], 'tempfile.png');
        croppedImage.title = $('#image-title-input').val();
        fileToBase64(blob).then((base64) => {
            $(cropImagePreviewSelector).show();
            $(cropImagePreviewSelector).attr('src', base64);
            $(cropImagePreviewSelector).attr('title', croppedImage.title);
        });
        $('#cropper-img-modal').modal('hide');
    });
}

function onFileCroperChange() {
    var fileData = $(this)[0].files[0];
    fileToBase64(fileData).then((base64) => {
        var image = $("#upload-img");
        image.attr("src", base64);
        cropper.replace(base64)
    });
}

