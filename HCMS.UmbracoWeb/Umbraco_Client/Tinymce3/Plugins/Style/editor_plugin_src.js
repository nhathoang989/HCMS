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
	tinymce.create('tinymce.plugins.StylePlugin', {
		init : function(ed, url) {
			// Register commands
			ed.addCommand('mceStyleProps', function() {

				var applyStyleToBlocks = false;
				var blocks = ed.selection.getSelectedBlocks();
				var styles = [];

				if (blocks.length === 1) {
					styles.push(ed.selection.getNode().style.cssText);
				}
				else {
					tinymce.each(blocks, function(block) {
						styles.push(ed.dom.getAttrib(block, 'style'));
					});
					applyStyleToBlocks = true;
				}

				ed.windowManager.open({
					file : url + '/props.htm',
					width : 480 + parseInt(ed.getLang('style.delta_width', 0)),
					height : 340 + parseInt(ed.getLang('style.delta_height', 0)),
					inline : 1
				}, {
					applyStyleToBlocks : applyStyleToBlocks,
					plugin_url : url,
					styles : styles
				});
			});

			ed.addCommand('mceSetElementStyle', function(ui, v) {
				if (e = ed.selection.getNode()) {
					ed.dom.setAttrib(e, 'style', v);
					ed.execCommand('mceRepaint');
				}
			});

			ed.onNodeChange.add(function(ed, cm, n) {
				cm.setDisabled('styleprops', n.nodeName === 'BODY');
			});

			// Register buttons
			ed.addButton('styleprops', {title : 'style.desc', cmd : 'mceStyleProps'});
		},

		getInfo : function() {
			return {
				longname : 'Style',
				author : 'Moxiecode Systems AB',
				authorurl : 'http://tinymce.moxieCustomAngularUmbraco.com',
				infourl : 'http://wiki.moxieCustomAngularUmbraco.com/index.php/TinyMCE:Plugins/style',
				version : tinymce.majorVersion + "." + tinymce.minorVersion
			};
		}
	});

	// Register plugin
	tinymce.PluginManager.add('style', tinymce.plugins.StylePlugin);
})();
