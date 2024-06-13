
import { createRouter, createWebHistory } 	from 'vue-router/auto'

const DEFAULT_TITLE = 'Vue Corp';

const router = createRouter(
{
	// linkActiveClass: 'active',
	// extendRoutes(routes) { routes.push( { path: '/About', name: 'AboutRedirect', redirect: '/About/How' } ) },
	history: createWebHistory()
})
	
router.beforeEach(async (to) => 
{
	// AuthStore must be created here because we are in .js not .vue file

	const publicPages 	= ['/','/login','/panzoom']
	const authRequired 	= !publicPages.includes(to.path)
	const authStore		= useAuthStore() 

	if (authRequired && !authStore.isLoggedIn) 
	{
		authStore.returnUrl = to.fullPath	
		return '/login'
	}
});

router.afterEach(() =>  // (to, from)
{
	// nextTick see: https://github.com/vuejs/vue-router/issues/914#issuecomment-384477609

	nextTick(() => 
	{		
		document.title =  DEFAULT_TITLE // + (to.name ? ' - '+ to.name : '');
	});
});

export default router 

	