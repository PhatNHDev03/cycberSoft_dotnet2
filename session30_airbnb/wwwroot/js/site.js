window.ScrollToTop = () =>{
    window.scrollTo({
        top:0,
        behavior:"smooth"
    })
};

function showFeedbackModal(feedbackModel){
    console.log(feedbackModel);
    let userNameFromModel = feedbackModel.userName;
    let userName = document.getElementById('user-name');
    userName.innerHTML = userNameFromModel;
    var feedbackModal = new bootstrap.Modal(document.getElementById('feedbackModal'));
    feedbackModal.show();
}