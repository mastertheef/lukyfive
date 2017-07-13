requirejs.config({
	baseUrl: "/",
	paths: {
		jquery: 'Scripts/jquery',
		react: 'Scripts/react/react',
		reactDom: 'Scripts/react/react-dom',
		
		jqueryMigrate: 'Scripts/jquery-migrate-1.2.1.min',
		jqueryEasing: 'Scripts/jquery.easing.1.3',
		jqueryMobilemenu: 'Scripts/jquery.mobilemenu',
		jqueryCookie: 'Scripts/jquery.cookie',
		jqueryMouseweeel: 'Scripts/jquery.mousewheel.min',
		jquerySmoothScroll: 'Scripts/jquery.simplr.smoothscroll.min',
		jqueryStellar: 'Scripts/stellar/jquery.stellar',
		jqueryToTop: 'Scripts/jquery.ui.totop',
		jqueryEqualheights: 'Scripts/jquery.equalheights',
        
		bootstrap: 'Scripts/bootstrap.min',
		respond: 'Scripts/respond',
		dropzone: 'Scripts/dropzone/dropzone',

	    //tmstickup: 'Scripts/tmstickup',
	    tmscripts: 'Sctipts/tm-scripts',
		device: 'Scripts/device.min',
		superfish: 'Scripts/superfish'
	},
	shim: {
        jquery: {
        	exports: 'jQuery'
        },
		jqueryToTop: ['jquery'],
		jqueryEqualheights: ['jquery'],
		jqueryStellar: ['jquery'],
	    jqueryCookie: ['jquery'],
	    superfish: ['jquery'],
	    jquerySmoothScroll: ['jquery'],
	    jqueryMouseweeel: ['jquery'],
	    jqueryMobilemenu: ['jquery'],
	    jqueryEasing: ['jquery'],
	    jqueryMigrate: ['jquery'],
        
        
	}
});