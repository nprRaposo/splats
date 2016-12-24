var editSerieView =  {
	f : function (){
		return $('#editSerieFrm');
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
		debugger;
		postForm(me.f(), function () { alert('Updated') });
	}
}

$(document).ready(function () {
	editSerieView.init();
});
