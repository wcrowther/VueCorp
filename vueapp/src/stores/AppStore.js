
export const useAppStore = defineStore('AppStore',
{
    state: () => 
    ({
        sideBarHidden:          false,
        layoutEscapeKeyOn:      true,
        showPrevNext:           useLocalStorage('showPrevNext',  true),
        showBreakpoints:        useLocalStorage('showBreakpoints', false),
        showNotification:       useLocalStorage('showNotification', true),
        showNewChatMessages:        useLocalStorage('showNewChatMessages', true),
        persistSearch:          useLocalStorage('persistSearch', false),
        altTheme:               useLocalStorage('altTheme', false),
        infoLevel:              useLocalStorage('infoLevel', 2),
        pagerDebugger:          useLocalStorage('pagerDebugger', false),
        pagerDebuggerX:         useLocalStorage('pagerDebuggerX', 400),
        pagerDebuggerY:         useLocalStorage('pagerDebuggerY', 30),
        activeFloater:          useLocalStorage('activeFloater', ''),
        baseApiUrl:             import.meta.env.VITE_API_URL,
        apiDocsUrl:             import.meta.env.VITE_API_DOCS_URL,
        baseUrl:                import.meta.env.BASE_URL,
        mode:                   import.meta.env.MODE
    }),
    getters:{},
    actions:{
        async resetLocalStorage ()
        {
            var local =  [ 'showPrevNext','showBreakpoints','persistSearch','altTheme',
                           'infoLevel','pagerDebugger','pagerDebuggerX','pagerDebuggerY',
                           'activeFloater','showNewChatMessages' ];

            local.forEach(item => { localStorage.removeItem(item) });

            useToastStore().showInfo(`Removed local App preferences`)
            setTimeout(() => { this.router.go(0); }, 2000);
        }
    }
})

