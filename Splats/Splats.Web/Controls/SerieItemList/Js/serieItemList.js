var serieItemListView = {
	divId : '',

	f: function () {
		return $('#' + divId);
	},

	init: function (containerDivId) {
		var me = this;
		divId = containerDivId;
		me.attachEvents(me.f());
	},

	attachEvents: function (f) {
		var me = this;
		f.find('#lnkDeleteSerie').click(function (data) {
			var params = new Object();
			params.success = data;
			$.confirm("Are you sure of deleting the serie?", me.onDelete, null, params );
			
		});
	},

	onDelete: function (data) {
		
		postTo($(data.currentTarget).attr('data-url'), function () {
			$.notificationSuccess("Delete was successfully done");
		}, function () {
			$.notificationError("It was an error deleting the serie");
		});
	}
}
