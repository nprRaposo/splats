var editSerieView =  {
	f : function (){
		return $('#editSerieFrm');
	},

	father : function (){
		return homeSerieView;
	},

	m: function (){
		return $('#mdlEditSerie');
	},

	init: function () {
		var me = this;
		me.attachEvents(me.f(), me.m());
	},

	attachEvents: function (f,m) {
		var me = this;
		m.find('#btnSave').on('click', me.editSerie);
	},

	editSerie : function () {
		var me = editSerieView;
		postForm(me.f(), function (data) {
			me.onSerieUpdated(data);
		});
	},

	onSerieUpdated: function (data) {
		if (data.Result == false) {
			$.notificationError('Error on updating Serie');
			return;
		}
		$.notificationSuccess('The serie with ID ' + data.SerieId + ' has been updated correctly');
		$('#modal-container').modal('hide');
		var me = editSerieView;
		me.father().reloadSerie(data.SerieId);
	}
}

$(document).ready(function () {
	editSerieView.init();
});
