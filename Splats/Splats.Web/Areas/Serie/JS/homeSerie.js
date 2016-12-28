var homeSerieView =  {
	c: function (){
		return $('#divHomeSerie');
	},

	f: function() {
		return $('#frmCreateSerie');
	},

	init: function () {
		var me = this;
		me.attachEvents(me.c());
	},

	attachEvents: function (c) {
		var me = homeSerieView;
		c.find('#btnCreateMovie').on('click', me.openMdlCreate);
	},

	reloadSerie : function (idSerie) {
		$("#divSerie" + idSerie).load(urlReload+ '?serieId=' + idSerie);
	},

	openMdlCreate: function () {
		
	}
}

$(document).ready(function () {
	homeSerieView.init();
});
