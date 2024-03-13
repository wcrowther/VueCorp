<script setup>

    const authStore	        = useAuthStore()
    const { logout }        = authStore
	const 
    { 
        firstInitial,authUser,
        isLoggedIn,isBusy,
        expiration 
    }                       = storeToRefs(authStore)        
    const { copy }          = useClipboard()

    const appStore          = useAppStore()
    const { showPrevNext,
        showBreakpoints }   = storeToRefs(appStore)

    const showPopout        = ref(false)
    const pinPopout         = ref(false)

	const popoutToggle      = (show) => { if(!pinPopout.value) showPopout.value= show }
    const logoutUser        = () => 
    {
        showPopout.value = false
        logout()
    }  

    const tokenToClipboard  = () => copy(authUser.value.Token)

    const fullName = computed(() => authUser.value.LastName ? `${authUser.value.FirstName} ${authUser.value.LastName}` : '---')

    const tokenDisplay      = computed(() => 
    {
        let token = authUser.value.Token
        return token ? `${token.slice(0,6)}...${token.slice(token.length - 6)}` : '---'
    })

</script>

<template>

    <div class="relative" id="loginPopout" @mouseleave="popoutToggle(false)">

        <div v-if="isLoggedIn" @click="popoutToggle(true)" title="Show user popout" id="popout"
            class="relative z-[100] text-white h-10 w-10 tracking-wider rounded-full bg-gray-700 flex-center ">
            <span class="text-sm m-auto">{{firstInitial}}</span>
        </div>

        <router-link v-if="!isLoggedIn" title="Login"
            class="text-white tracking-wider rounded-full" to='/login'>Login 
        </router-link>
        
        <div v-if="showPopout"
            class="z-[90] absolute p-10 pb-12 h-[550px] w-[390px] top-0 rounded-tl-[30px] 
                flex flex-col flex-wrap items-start border border-color-gray bg-gradient-main 
                shadow-lg shadow-color-mid-gray">
            
            <IconSymbol v-if="pinPopout" class="icon-symbol" @click="pinPopout=!pinPopout" icon="heroicons:lock-closed-20-solid" />
            <IconSymbol v-else           class="icon-symbol" @click="pinPopout=!pinPopout" icon="heroicons:lock-open-20-solid" />

            <!--     
                <div class="w-full">{{ testValue }}</div>
                <SwitchButton class="bg-color-blue-gray text-white font-bold" title="Toggle Pin"  
                    buttonName="PinPopout" v-model="testValue" /> 
            -->

            <div class="flex h-9 self-start justify-between my-5 w-full ">
                <button class="default-button hover:bg-warm-100" @click="logoutUser">Logout</button>
            </div>

            <div class="label-row">
                <div class="label-title">UserId:</div>
                <div class="label-value">{{ authUser.UserId || 0 }}</div>
            </div>
            <div class="label-row">
                <div class="label-title">UserName:</div>
                <div class="label-value">{{ authUser.UserName }}</div>
            </div>
            <div class="label-row">
                <div class="label-title">Full Name:</div>
                <div class="label-value">{{ fullName }}</div>
            </div>
            <div class="label-row">
                <div class="label-title">UserEmail:</div>
                <div class="label-value">{{ authUser.UserEmail }}</div>
            </div>
            <div class="label-row">
                <div class="label-title">Is LoggedIn:</div>
                <div class="label-value">{{ isLoggedIn }}</div>
            </div>
            <div class="label-row">
                <div class="label-title">Is Busy:</div>
                <div class="label-value">{{ isBusy }}</div>
            </div>
            <div class="label-row">
                <div class="label-title">Expiration:</div>
                <div class="label-value">{{ dateTimeFormat(expiration) }}</div>
            </div>
            <div class="label-row">
                <div class="label-title">Token:</div>
                <div class="label-value flex items-center">{{ tokenDisplay }}
                    <IconSymbol class="text-color-mid-blue ml-2"  @click="tokenToClipboard" width="16px" icon="heroicons:clipboard-20-solid" />
                </div>
            </div>
            <div class="label-row">
                <div class="label-title" title="Prev/Next buttons for mobile pager(only show at low res)">Prev/Next</div>
                <div class="label-value">
                    <CheckboxInput labelName="" v-model="showPrevNext" />
                </div>
            </div>
            <div class="label-row">
                <div class="label-title" title="Show breakpoints in lower left">Breakpoints</div>
                <div class="label-value">
                    <CheckboxInput labelName="" v-model="showBreakpoints" />
                </div>
            </div>

            <!-- 
            <div class="flex">
                <div class="label-title">Numbers Only:</div>
                <div class="label-value flex flex-col">
                    <input class="" type="text" v-model="numbers" spellcheck="false" />
                    <div class="ml-2 mt-2">{{ numbersOnly(numbers, '-.,') }}</div>
                    <div class="ml-2 mt-2">{{ usPhoneFormat(numbers) }}</div>
                </div>
            </div> -->

        </div>
    </div>

</template>

<style lang="postcss" scoped>
    .label-row      { @apply flex h-9 items-center }
    .label-title    { @apply w-32 font-bold whitespace-nowrap }
    .label-value    { @apply w-52 flex-grow whitespace-nowrap }
    .icon-symbol    { @apply absolute top-3 right-3 text-color-mid-blue }

</style> 
 
