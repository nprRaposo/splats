function postForm(form, successCallBack, failureCallBack) {
	$.ajax({
		url: form.attr("action"),
		type: 'post',
		dataType: 'json',
		data: form.serialize(),
		success: successCallBack,
		fail: failureCallBack
	});
}