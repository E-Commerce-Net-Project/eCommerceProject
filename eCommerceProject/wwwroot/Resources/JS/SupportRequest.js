function GetMessagesForCustomer(customerId) {
    $.ajax({
        url: '/Admin/SupportRequest/GetMessagesForCustomer',
        data: { customerId: customerId },
        type: 'GET',
        success: function (data) {
            var customerName = document.querySelector('.chat-about h6');
            customerName.innerHTML = data.fullName;

            var customerIcon= document.querySelector('#cutomerIcon');
            customerIcon.innerHTML = data.fullName[0];

            var message = document.querySelector('#messageContent');
            message.innerHTML = data.message;
        },
        error: function () {
            alert('Bir hata oluþtu.');
        }
    });
}
