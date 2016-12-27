(function($)
{
	$.notificationSuccess = function(message)
	{
		toastr["success"](message);
	};

	$.notificationError = function (message) {
		toastr["error"](message);
	};

	$.confirm = function (message, successCallback, errorCallback, params) {
		bootbox.confirm(message, function (result) {
			if (result)
				successCallback(params.success);
			else {
				if (errorCallback != undefined && errorCallback != null)
					errorCallback(params.error);
			}

			$('#modal-container').modal('hide');
				
		});
	};
})(jQuery);