$(function () {
    var l = abp.localization.getResource('AbpUi');

    abp.log.debug('Index.js initialized!');

    var _permissionsModal = new abp.ModalManager(
        abp.appPath + 'AbpPermissionManagement/PermissionManagementModal'
    );

    $.ajaxSetup({
        error: function (xhr) {
            if (xhr.status === 401) {
                location.href = '/account/login';
            }
            if (xhr.status === 403) {
                abp.notify.info(l('DefaultErrorMessage403'));
            }
        }
    });

    $('.permission-manager').on('click', function () {
        _permissionsModal.open({
            providerName: 'R',
            providerKey: "admin",
        });
    })

    var _featuresModal = new abp.ModalManager(
        abp.appPath + 'FeatureManagement/FeatureManagementModal'
    );

    $('.feature-manager').on('click', function () {
        _featuresModal.open({
            providerName: 'U',
            providerKey: abp.currentUser.id
        });
    });
});