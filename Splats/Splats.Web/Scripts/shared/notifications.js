(function($)
{
	$.notificationSuccess = function(message)
	{
		toastr["success"](message);
	};

	$.notificationError = function (message) {
		toastr["error"](message);
	};
})(jQuery);