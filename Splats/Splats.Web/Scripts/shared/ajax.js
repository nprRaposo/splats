function postForm(form, successCallBack, failureCallBack) {
	$.ajax({
		url: form.attr("action"),
		type: 'post',
		dataType: 'json',
		data: form.serialize(),
		success: successCallBack,
		error: failureCallBack
	});
}

function postTo(url, successCallBack, failureCallBack) {
	$.ajax({
		url: url,
		type: 'post',
		dataType: 'json',
		success: successCallBack,
		error: failureCallBack
	});
}