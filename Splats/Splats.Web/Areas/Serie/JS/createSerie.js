var createSerieView =  {
	f : function (){
		return $('#frmCreateSerie');
	},

	father : function (){
		return homeSerieView;
	},

	m: function (){
		return $('#mdlCreateSerie');
	},

	init: function () {
		var me = this;
		me.attachEvents(me.f(), me.m());
	},

	attachEvents: function (f,m) {
		var me = this;
		m.find('#btnSave').on('click', me.createSerie);
	},

	createSerie : function () {
		var me = createSerieView;
		postForm(me.f(), function (data) {
			me.onSerieCreated(data);
		});
	},

	onSerieCreated: function (data) {
		if (data.Result == false) {
			$.notificationError('Error on creating Serie');
			return;
		}
		$.notificationSuccess('The serie ' + data.SerieName + ' has been created');
		$('#modal-container').modal('hide');
		location.reload();
	}
}


