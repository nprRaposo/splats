var homeSerieView =  {
	c: function (){
		return $('#divHomeSerie');
	},

	init: function () {
		var me = this;
		me.attachEvents(me.c());
	},

	attachEvents: function (c) {
		
	},

	reloadSerie : function (idSerie) {
		$("#divSerie" + idSerie).load(urlReload+ '?serieId=' + idSerie);
	}
}

$(document).ready(function () {
	homeSerieView.init();
});
