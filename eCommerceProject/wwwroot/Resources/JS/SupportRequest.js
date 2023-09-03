function GetMessagesForCustomer(customerId) {
    const options = { year: 'numeric', month: 'long', day: 'numeric', hour: "2-digit", minute: "2-digit" };
    $.ajax({
        url: '/Admin/SupportRequest/GetMessagesForCustomer',
        data: { customerId: customerId },
        type: 'GET',
        success: function (data) {
            var customerName = document.querySelector('.chat-about h6');
            customerName.innerHTML = "Gonderen: " + data.fullName;

            var message = document.querySelector('#messageContent');
            message.innerHTML = data.message;

            var subject = document.querySelector('#chatsubject');
            subject.innerHTML = "Konu: " + data.subject;

            var messageDate = document.querySelector('#message-date');         
            messageDate.innerHTML = new Date(data.messageSentTime).toLocaleDateString("tr-TR", options);
        },
        error: function () {
            alert('Bir hata oluþtu.');
        }
    });
}
