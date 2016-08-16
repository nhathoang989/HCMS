/**
 * editor_plugin_src.js
 *
 * Copyright 2009, Moxiecode Systems AB
 * Released under LGPL License.
 *
 * License: http://tinymce.moxieCustomAngularUmbraco.com/license
 * Contributing: http://tinymce.moxieCustomAngularUmbraco.com/contributing
 */

(function() {
	tinymce.create('tinymce.plugins.Print', {
		init : function(ed, url) {
			ed.addCommand('mcePrint', function() {
				ed.getWin().print();
			});

			ed.addButton('print', {title : 'print.print_desc', cmd : 'mcePrint'});
		},

		getInfo : function() {
			return {
				longname : 'Print',
				author : 'Moxiecode Systems AB',
				authorurl : 'http://tinymce.moxieCustomAngularUmbraco.com',
				infourl : 'http://wiki.moxieCustomAngularUmbraco.com/index.php/TinyMCE:Plugins/print',
				version : tinymce.majorVersion + "." + tinymce.minorVersion
			};
		}
	});

	// Register plugin
	tinymce.PluginManager.add('print', tinymce.plugins.Print);
})();
