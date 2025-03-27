
export const useAppStore = defineStore('AppStore',
{
    state: () => 
    ({
        sideBarHidden:          false,
        showPrevNext:           useLocalStorage('showPrevNext',  true),
        showBreakpoints:        useLocalStorage('showBreakpoints', false),
        persistSearch:          useLocalStorage('persistSearch', true),
        altTheme:               useLocalStorage('altTheme', false),
        infoLevel:              useLocalStorage('infoLevel', 2),
        pagerDebugger:          useLocalStorage('pagerDebugger', false),
        baseApiUrl:             import.meta.env.VITE_API_URL,
        baseUrl:                import.meta.env.BASE_URL,
        mode:                   import.meta.env.MODE
    }),
    getters:{},
    actions:{}
})

