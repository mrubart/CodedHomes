OfflineUtility = function (onlineCallback, offlineCallback, pollingUrl) {
	var DEBUG_MODE = true;

	if (!pollingUrl) {
		pollingUrl = '/o.html';
	}

	var currentEventName = 'unknown',
		debugCheckBoxId = '___forceOffline',

		fireEvent = function (name, data) {
			var e = document.createEvent("Event");
			e.initEvent(name, true, true);
			e.data = data;
			window.dispatchEvent(e);
		},
		fireEventIfStatusChanges = function (eventName) {
			if (currentEventName != eventName) {
				currentEventName = eventName;
				fireEvent(eventName, {});
			}
		},
		getUrl = function () {
			if (DEBUG_MODE) {
				if($('#' + debugCheckBoxId).is(':checked')){
					return 'jajhfasdlkfasfkjlfd.html';
				}
			}
			return pollingUrl;
		},
		detectOnlineStatus = function(url){
			$.get(url).done(function(){
				fireEventIfStatusChanges('onlineCustom');
			}).fail(function(){
				fireEventIdStatusChanges('offlineCustom');
			});
		},
		autoReloadOnCacheUpdate = function(){
			window.applicationCache.swapCache();
			location.reload();
		};

	if(DEBUG_MODE){
		var container = $('<siv></div>'),
			checkbox = $('<input type="checkbox" width="auto" />'),
			label = $('<label>Simulare Offline</label>');

		checkbox.attr('id', debugCheckBoxId);
		checkbox.attr('name', debugCheckBoxId);

		label.attr('for', debugCheckBoxId);

		container.attr('style', 'position:fixed; left:4px;bottom:4px');
		container.append(checkbox);
		container.append(label);

		$('body').append(container);
		
	}

	if(window.applicationCache){
		$(window.applicationCache).on('updateready',autoReloadOnCacheUpdate);
	}

	if(onlineCallback){
		window.addEventListener('onlineCustom', onlineCallback);
	}

	if(offlineCallback){
		window.addEventListener('offlineCustom', offlineCallback);
	}

	if(onlineCallback || offlineCallback){
		detectOnlineStatus();
		setInterval(function(){
			var url = getUrl();
			detectOnlineStatus(url);
		},3000);
	}
};

$(function () {
	var
		msg = $('#msg'),

	doWhenOnline = function() {
		msg.text('online');
	},

	doWhenOffline = function () {
		msg.text('OFFLINE');
	};

	var offlineUtility = new OfflineUtility(doWhenOnline, doWhenOffline);
});