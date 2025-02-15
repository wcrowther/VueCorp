/* eslint-disable */
/* prettier-ignore */
// @ts-nocheck
// noinspection JSUnusedGlobalSymbols
// Generated by unplugin-auto-import
export {}
declare global {
  const Account: typeof import('./src/models/Account.js')['Account']
  const AuthRequest: typeof import('./src/models/AuthRequest.js')['AuthRequest']
  const Draggable: typeof import('@vueuse/core')['useDraggable']
  const EffectScope: typeof import('vue')['EffectScope']
  const KeyboardListeners: typeof import('./src/helpers/KeyboardListeners.js')['KeyboardListeners']
  const PageItem: typeof import('./src/models/pager.js')['PageItem']
  const PagedList: typeof import('./src/models/pager.js')['PagedList']
  const Pager: typeof import('./src/models/pager.js')['Pager']
  const Search: typeof import('./src/models/pager.js')['Search']
  const SearchForAccount: typeof import('./src/models/pager.js')['SearchForAccount']
  const User: typeof import('./src/models/user.js')['User']
  const accountValidator: typeof import('./src/helpers/validators.js')['accountValidator']
  const apiCall: typeof import('./src/helpers/ApiCall.js')['apiCall']
  const apiGet: typeof import('./src/helpers/ApiCall.js')['apiGet']
  const apiPost: typeof import('./src/helpers/ApiCall.js')['apiPost']
  const authRequestValidator: typeof import('./src/helpers/validators.js')['authRequestValidator']
  const authSignupValidator: typeof import('./src/helpers/validators.js')['authSignupValidator']
  const computed: typeof import('vue')['computed']
  const createApp: typeof import('vue')['createApp']
  const customRef: typeof import('vue')['customRef']
  const dateFormat: typeof import('./src/helpers/global.js')['dateFormat']
  const dateTimeFormat: typeof import('./src/helpers/global.js')['dateTimeFormat']
  const defineAsyncComponent: typeof import('vue')['defineAsyncComponent']
  const defineComponent: typeof import('vue')['defineComponent']
  const defineLoader: typeof import('vue-router/auto')['defineLoader']
  const definePage: typeof import('unplugin-vue-router/runtime')['_definePage']
  const defineStore: typeof import('pinia')['defineStore']
  const effectScope: typeof import('vue')['effectScope']
  const getCurrentInstance: typeof import('vue')['getCurrentInstance']
  const getCurrentScope: typeof import('vue')['getCurrentScope']
  const h: typeof import('vue')['h']
  const hasKeys: typeof import('./src/helpers/global.js')['hasKeys']
  const inject: typeof import('vue')['inject']
  const isProxy: typeof import('vue')['isProxy']
  const isReactive: typeof import('vue')['isReactive']
  const isReadonly: typeof import('vue')['isReadonly']
  const isRef: typeof import('vue')['isRef']
  const log: typeof import('./src/helpers/global.js')['log']
  const logJson: typeof import('./src/helpers/global.js')['logJson']
  const markRaw: typeof import('vue')['markRaw']
  const nextTick: typeof import('vue')['nextTick']
  const numbersOnly: typeof import('./src/helpers/global.js')['numbersOnly']
  const onActivated: typeof import('vue')['onActivated']
  const onBeforeMount: typeof import('vue')['onBeforeMount']
  const onBeforeRouteLeave: typeof import('vue-router/auto')['onBeforeRouteLeave']
  const onBeforeRouteUpdate: typeof import('vue-router/auto')['onBeforeRouteUpdate']
  const onBeforeUnmount: typeof import('vue')['onBeforeUnmount']
  const onBeforeUpdate: typeof import('vue')['onBeforeUpdate']
  const onDeactivated: typeof import('vue')['onDeactivated']
  const onErrorCaptured: typeof import('vue')['onErrorCaptured']
  const onMounted: typeof import('vue')['onMounted']
  const onRenderTracked: typeof import('vue')['onRenderTracked']
  const onRenderTriggered: typeof import('vue')['onRenderTriggered']
  const onScopeDispose: typeof import('vue')['onScopeDispose']
  const onServerPrefetch: typeof import('vue')['onServerPrefetch']
  const onUnmounted: typeof import('vue')['onUnmounted']
  const onUpdated: typeof import('vue')['onUpdated']
  const pagerPageSize: typeof import('./src/helpers/pagerPageSize.js')['pagerPageSize']
  const provide: typeof import('vue')['provide']
  const reactive: typeof import('vue')['reactive']
  const readonly: typeof import('vue')['readonly']
  const ref: typeof import('vue')['ref']
  const resolveComponent: typeof import('vue')['resolveComponent']
  const roleList: typeof import('./src/helpers/roleList.js')['roleList']
  const shallowReactive: typeof import('vue')['shallowReactive']
  const shallowReadonly: typeof import('vue')['shallowReadonly']
  const shallowRef: typeof import('vue')['shallowRef']
  const storeToRefs: typeof import('pinia')['storeToRefs']
  const timeFormat: typeof import('./src/helpers/global.js')['timeFormat']
  const toRaw: typeof import('vue')['toRaw']
  const toRef: typeof import('vue')['toRef']
  const toRefs: typeof import('vue')['toRefs']
  const toValue: typeof import('vue')['toValue']
  const triggerRef: typeof import('vue')['triggerRef']
  const unref: typeof import('vue')['unref']
  const usPhoneFormat: typeof import('./src/helpers/global.js')['usPhoneFormat']
  const usStatesList: typeof import('./src/helpers/usStates.js')['usStatesList']
  const useAccountsStore: typeof import('./src/stores/AccountsStore.js')['useAccountsStore']
  const useAppStore: typeof import('./src/stores/AppStore.js')['useAppStore']
  const useAttrs: typeof import('vue')['useAttrs']
  const useAuthStore: typeof import('./src/stores/AuthStore.js')['useAuthStore']
  const useClipboard: typeof import('@vueuse/core')['useClipboard']
  const useCssModule: typeof import('vue')['useCssModule']
  const useCssVars: typeof import('vue')['useCssVars']
  const useDebounceFn: typeof import('@vueuse/core')['useDebounceFn']
  const useImagesStore: typeof import('./src/stores/ImagesStore.js')['useImagesStore']
  const useLocalStorage: typeof import('@vueuse/core')['useLocalStorage']
  const useMessageStore: typeof import('./src/stores/messageStore.js')['useMessageStore']
  const useRoute: typeof import('vue-router/auto')['useRoute']
  const useRouter: typeof import('vue-router/auto')['useRouter']
  const useSlots: typeof import('vue')['useSlots']
  const useUsersStore: typeof import('./src/stores/UsersStore.js')['useUsersStore']
  const useVuelidate: typeof import('@vuelidate/core')['useVuelidate']
  const useWindowSize: typeof import('@vueuse/core')['useWindowSize']
  const userValidator: typeof import('./src/helpers/validators.js')['userValidator']
  const watch: typeof import('vue')['watch']
  const watchEffect: typeof import('vue')['watchEffect']
  const watchPostEffect: typeof import('vue')['watchPostEffect']
  const watchSyncEffect: typeof import('vue')['watchSyncEffect']
}
// for type re-export
declare global {
  // @ts-ignore
  export type { Component, ComponentPublicInstance, ComputedRef, ExtractDefaultPropTypes, ExtractPropTypes, ExtractPublicPropTypes, InjectionKey, PropType, Ref, VNode, WritableComputedRef } from 'vue'
  import('vue')
}
// for vue template auto import
import { UnwrapRef } from 'vue'
declare module 'vue' {
  interface GlobalComponents {}
  interface ComponentCustomProperties {
    readonly Account: UnwrapRef<typeof import('./src/models/Account.js')['Account']>
    readonly AuthRequest: UnwrapRef<typeof import('./src/models/AuthRequest.js')['AuthRequest']>
    readonly Draggable: UnwrapRef<typeof import('@vueuse/core')['useDraggable']>
    readonly EffectScope: UnwrapRef<typeof import('vue')['EffectScope']>
    readonly KeyboardListeners: UnwrapRef<typeof import('./src/helpers/KeyboardListeners.js')['KeyboardListeners']>
    readonly PageItem: UnwrapRef<typeof import('./src/models/pager.js')['PageItem']>
    readonly PagedList: UnwrapRef<typeof import('./src/models/pager.js')['PagedList']>
    readonly Pager: UnwrapRef<typeof import('./src/models/pager.js')['Pager']>
    readonly Search: UnwrapRef<typeof import('./src/models/pager.js')['Search']>
    readonly SearchForAccount: UnwrapRef<typeof import('./src/models/pager.js')['SearchForAccount']>
    readonly User: UnwrapRef<typeof import('./src/models/user.js')['User']>
    readonly accountValidator: UnwrapRef<typeof import('./src/helpers/validators.js')['accountValidator']>
    readonly apiCall: UnwrapRef<typeof import('./src/helpers/ApiCall.js')['apiCall']>
    readonly apiGet: UnwrapRef<typeof import('./src/helpers/ApiCall.js')['apiGet']>
    readonly apiPost: UnwrapRef<typeof import('./src/helpers/ApiCall.js')['apiPost']>
    readonly authRequestValidator: UnwrapRef<typeof import('./src/helpers/validators.js')['authRequestValidator']>
    readonly authSignupValidator: UnwrapRef<typeof import('./src/helpers/validators.js')['authSignupValidator']>
    readonly computed: UnwrapRef<typeof import('vue')['computed']>
    readonly createApp: UnwrapRef<typeof import('vue')['createApp']>
    readonly customRef: UnwrapRef<typeof import('vue')['customRef']>
    readonly dateFormat: UnwrapRef<typeof import('./src/helpers/global.js')['dateFormat']>
    readonly dateTimeFormat: UnwrapRef<typeof import('./src/helpers/global.js')['dateTimeFormat']>
    readonly defineAsyncComponent: UnwrapRef<typeof import('vue')['defineAsyncComponent']>
    readonly defineComponent: UnwrapRef<typeof import('vue')['defineComponent']>
    readonly defineLoader: UnwrapRef<typeof import('vue-router/auto')['defineLoader']>
    readonly definePage: UnwrapRef<typeof import('unplugin-vue-router/runtime')['_definePage']>
    readonly defineStore: UnwrapRef<typeof import('pinia')['defineStore']>
    readonly effectScope: UnwrapRef<typeof import('vue')['effectScope']>
    readonly getCurrentInstance: UnwrapRef<typeof import('vue')['getCurrentInstance']>
    readonly getCurrentScope: UnwrapRef<typeof import('vue')['getCurrentScope']>
    readonly h: UnwrapRef<typeof import('vue')['h']>
    readonly hasKeys: UnwrapRef<typeof import('./src/helpers/global.js')['hasKeys']>
    readonly inject: UnwrapRef<typeof import('vue')['inject']>
    readonly isProxy: UnwrapRef<typeof import('vue')['isProxy']>
    readonly isReactive: UnwrapRef<typeof import('vue')['isReactive']>
    readonly isReadonly: UnwrapRef<typeof import('vue')['isReadonly']>
    readonly isRef: UnwrapRef<typeof import('vue')['isRef']>
    readonly log: UnwrapRef<typeof import('./src/helpers/global.js')['log']>
    readonly logJson: UnwrapRef<typeof import('./src/helpers/global.js')['logJson']>
    readonly markRaw: UnwrapRef<typeof import('vue')['markRaw']>
    readonly nextTick: UnwrapRef<typeof import('vue')['nextTick']>
    readonly numbersOnly: UnwrapRef<typeof import('./src/helpers/global.js')['numbersOnly']>
    readonly onActivated: UnwrapRef<typeof import('vue')['onActivated']>
    readonly onBeforeMount: UnwrapRef<typeof import('vue')['onBeforeMount']>
    readonly onBeforeRouteLeave: UnwrapRef<typeof import('vue-router/auto')['onBeforeRouteLeave']>
    readonly onBeforeRouteUpdate: UnwrapRef<typeof import('vue-router/auto')['onBeforeRouteUpdate']>
    readonly onBeforeUnmount: UnwrapRef<typeof import('vue')['onBeforeUnmount']>
    readonly onBeforeUpdate: UnwrapRef<typeof import('vue')['onBeforeUpdate']>
    readonly onDeactivated: UnwrapRef<typeof import('vue')['onDeactivated']>
    readonly onErrorCaptured: UnwrapRef<typeof import('vue')['onErrorCaptured']>
    readonly onMounted: UnwrapRef<typeof import('vue')['onMounted']>
    readonly onRenderTracked: UnwrapRef<typeof import('vue')['onRenderTracked']>
    readonly onRenderTriggered: UnwrapRef<typeof import('vue')['onRenderTriggered']>
    readonly onScopeDispose: UnwrapRef<typeof import('vue')['onScopeDispose']>
    readonly onServerPrefetch: UnwrapRef<typeof import('vue')['onServerPrefetch']>
    readonly onUnmounted: UnwrapRef<typeof import('vue')['onUnmounted']>
    readonly onUpdated: UnwrapRef<typeof import('vue')['onUpdated']>
    readonly pagerPageSize: UnwrapRef<typeof import('./src/helpers/pagerPageSize.js')['pagerPageSize']>
    readonly provide: UnwrapRef<typeof import('vue')['provide']>
    readonly reactive: UnwrapRef<typeof import('vue')['reactive']>
    readonly readonly: UnwrapRef<typeof import('vue')['readonly']>
    readonly ref: UnwrapRef<typeof import('vue')['ref']>
    readonly resolveComponent: UnwrapRef<typeof import('vue')['resolveComponent']>
    readonly roleList: UnwrapRef<typeof import('./src/helpers/roleList.js')['roleList']>
    readonly shallowReactive: UnwrapRef<typeof import('vue')['shallowReactive']>
    readonly shallowReadonly: UnwrapRef<typeof import('vue')['shallowReadonly']>
    readonly shallowRef: UnwrapRef<typeof import('vue')['shallowRef']>
    readonly storeToRefs: UnwrapRef<typeof import('pinia')['storeToRefs']>
    readonly timeFormat: UnwrapRef<typeof import('./src/helpers/global.js')['timeFormat']>
    readonly toRaw: UnwrapRef<typeof import('vue')['toRaw']>
    readonly toRef: UnwrapRef<typeof import('vue')['toRef']>
    readonly toRefs: UnwrapRef<typeof import('vue')['toRefs']>
    readonly toValue: UnwrapRef<typeof import('vue')['toValue']>
    readonly triggerRef: UnwrapRef<typeof import('vue')['triggerRef']>
    readonly unref: UnwrapRef<typeof import('vue')['unref']>
    readonly usPhoneFormat: UnwrapRef<typeof import('./src/helpers/global.js')['usPhoneFormat']>
    readonly usStatesList: UnwrapRef<typeof import('./src/helpers/usStates.js')['usStatesList']>
    readonly useAccountsStore: UnwrapRef<typeof import('./src/stores/AccountsStore.js')['useAccountsStore']>
    readonly useAppStore: UnwrapRef<typeof import('./src/stores/AppStore.js')['useAppStore']>
    readonly useAttrs: UnwrapRef<typeof import('vue')['useAttrs']>
    readonly useAuthStore: UnwrapRef<typeof import('./src/stores/AuthStore.js')['useAuthStore']>
    readonly useClipboard: UnwrapRef<typeof import('@vueuse/core')['useClipboard']>
    readonly useCssModule: UnwrapRef<typeof import('vue')['useCssModule']>
    readonly useCssVars: UnwrapRef<typeof import('vue')['useCssVars']>
    readonly useDebounceFn: UnwrapRef<typeof import('@vueuse/core')['useDebounceFn']>
    readonly useImagesStore: UnwrapRef<typeof import('./src/stores/ImagesStore.js')['useImagesStore']>
    readonly useLocalStorage: UnwrapRef<typeof import('@vueuse/core')['useLocalStorage']>
    readonly useMessageStore: UnwrapRef<typeof import('./src/stores/messageStore.js')['useMessageStore']>
    readonly useRoute: UnwrapRef<typeof import('vue-router/auto')['useRoute']>
    readonly useRouter: UnwrapRef<typeof import('vue-router/auto')['useRouter']>
    readonly useSlots: UnwrapRef<typeof import('vue')['useSlots']>
    readonly useUsersStore: UnwrapRef<typeof import('./src/stores/UsersStore.js')['useUsersStore']>
    readonly useVuelidate: UnwrapRef<typeof import('@vuelidate/core')['useVuelidate']>
    readonly useWindowSize: UnwrapRef<typeof import('@vueuse/core')['useWindowSize']>
    readonly userValidator: UnwrapRef<typeof import('./src/helpers/validators.js')['userValidator']>
    readonly watch: UnwrapRef<typeof import('vue')['watch']>
    readonly watchEffect: UnwrapRef<typeof import('vue')['watchEffect']>
    readonly watchPostEffect: UnwrapRef<typeof import('vue')['watchPostEffect']>
    readonly watchSyncEffect: UnwrapRef<typeof import('vue')['watchSyncEffect']>
  }
}
declare module '@vue/runtime-core' {
  interface GlobalComponents {}
  interface ComponentCustomProperties {
    readonly Account: UnwrapRef<typeof import('./src/models/Account.js')['Account']>
    readonly AuthRequest: UnwrapRef<typeof import('./src/models/AuthRequest.js')['AuthRequest']>
    readonly Draggable: UnwrapRef<typeof import('@vueuse/core')['useDraggable']>
    readonly EffectScope: UnwrapRef<typeof import('vue')['EffectScope']>
    readonly KeyboardListeners: UnwrapRef<typeof import('./src/helpers/KeyboardListeners.js')['KeyboardListeners']>
    readonly PageItem: UnwrapRef<typeof import('./src/models/pager.js')['PageItem']>
    readonly PagedList: UnwrapRef<typeof import('./src/models/pager.js')['PagedList']>
    readonly Pager: UnwrapRef<typeof import('./src/models/pager.js')['Pager']>
    readonly Search: UnwrapRef<typeof import('./src/models/pager.js')['Search']>
    readonly SearchForAccount: UnwrapRef<typeof import('./src/models/pager.js')['SearchForAccount']>
    readonly User: UnwrapRef<typeof import('./src/models/user.js')['User']>
    readonly accountValidator: UnwrapRef<typeof import('./src/helpers/validators.js')['accountValidator']>
    readonly apiCall: UnwrapRef<typeof import('./src/helpers/ApiCall.js')['apiCall']>
    readonly apiGet: UnwrapRef<typeof import('./src/helpers/ApiCall.js')['apiGet']>
    readonly apiPost: UnwrapRef<typeof import('./src/helpers/ApiCall.js')['apiPost']>
    readonly authRequestValidator: UnwrapRef<typeof import('./src/helpers/validators.js')['authRequestValidator']>
    readonly authSignupValidator: UnwrapRef<typeof import('./src/helpers/validators.js')['authSignupValidator']>
    readonly computed: UnwrapRef<typeof import('vue')['computed']>
    readonly createApp: UnwrapRef<typeof import('vue')['createApp']>
    readonly customRef: UnwrapRef<typeof import('vue')['customRef']>
    readonly dateFormat: UnwrapRef<typeof import('./src/helpers/global.js')['dateFormat']>
    readonly dateTimeFormat: UnwrapRef<typeof import('./src/helpers/global.js')['dateTimeFormat']>
    readonly defineAsyncComponent: UnwrapRef<typeof import('vue')['defineAsyncComponent']>
    readonly defineComponent: UnwrapRef<typeof import('vue')['defineComponent']>
    readonly defineLoader: UnwrapRef<typeof import('vue-router/auto')['defineLoader']>
    readonly definePage: UnwrapRef<typeof import('unplugin-vue-router/runtime')['_definePage']>
    readonly defineStore: UnwrapRef<typeof import('pinia')['defineStore']>
    readonly effectScope: UnwrapRef<typeof import('vue')['effectScope']>
    readonly getCurrentInstance: UnwrapRef<typeof import('vue')['getCurrentInstance']>
    readonly getCurrentScope: UnwrapRef<typeof import('vue')['getCurrentScope']>
    readonly h: UnwrapRef<typeof import('vue')['h']>
    readonly hasKeys: UnwrapRef<typeof import('./src/helpers/global.js')['hasKeys']>
    readonly inject: UnwrapRef<typeof import('vue')['inject']>
    readonly isProxy: UnwrapRef<typeof import('vue')['isProxy']>
    readonly isReactive: UnwrapRef<typeof import('vue')['isReactive']>
    readonly isReadonly: UnwrapRef<typeof import('vue')['isReadonly']>
    readonly isRef: UnwrapRef<typeof import('vue')['isRef']>
    readonly log: UnwrapRef<typeof import('./src/helpers/global.js')['log']>
    readonly logJson: UnwrapRef<typeof import('./src/helpers/global.js')['logJson']>
    readonly markRaw: UnwrapRef<typeof import('vue')['markRaw']>
    readonly nextTick: UnwrapRef<typeof import('vue')['nextTick']>
    readonly numbersOnly: UnwrapRef<typeof import('./src/helpers/global.js')['numbersOnly']>
    readonly onActivated: UnwrapRef<typeof import('vue')['onActivated']>
    readonly onBeforeMount: UnwrapRef<typeof import('vue')['onBeforeMount']>
    readonly onBeforeRouteLeave: UnwrapRef<typeof import('vue-router/auto')['onBeforeRouteLeave']>
    readonly onBeforeRouteUpdate: UnwrapRef<typeof import('vue-router/auto')['onBeforeRouteUpdate']>
    readonly onBeforeUnmount: UnwrapRef<typeof import('vue')['onBeforeUnmount']>
    readonly onBeforeUpdate: UnwrapRef<typeof import('vue')['onBeforeUpdate']>
    readonly onDeactivated: UnwrapRef<typeof import('vue')['onDeactivated']>
    readonly onErrorCaptured: UnwrapRef<typeof import('vue')['onErrorCaptured']>
    readonly onMounted: UnwrapRef<typeof import('vue')['onMounted']>
    readonly onRenderTracked: UnwrapRef<typeof import('vue')['onRenderTracked']>
    readonly onRenderTriggered: UnwrapRef<typeof import('vue')['onRenderTriggered']>
    readonly onScopeDispose: UnwrapRef<typeof import('vue')['onScopeDispose']>
    readonly onServerPrefetch: UnwrapRef<typeof import('vue')['onServerPrefetch']>
    readonly onUnmounted: UnwrapRef<typeof import('vue')['onUnmounted']>
    readonly onUpdated: UnwrapRef<typeof import('vue')['onUpdated']>
    readonly pagerPageSize: UnwrapRef<typeof import('./src/helpers/pagerPageSize.js')['pagerPageSize']>
    readonly provide: UnwrapRef<typeof import('vue')['provide']>
    readonly reactive: UnwrapRef<typeof import('vue')['reactive']>
    readonly readonly: UnwrapRef<typeof import('vue')['readonly']>
    readonly ref: UnwrapRef<typeof import('vue')['ref']>
    readonly resolveComponent: UnwrapRef<typeof import('vue')['resolveComponent']>
    readonly roleList: UnwrapRef<typeof import('./src/helpers/roleList.js')['roleList']>
    readonly shallowReactive: UnwrapRef<typeof import('vue')['shallowReactive']>
    readonly shallowReadonly: UnwrapRef<typeof import('vue')['shallowReadonly']>
    readonly shallowRef: UnwrapRef<typeof import('vue')['shallowRef']>
    readonly storeToRefs: UnwrapRef<typeof import('pinia')['storeToRefs']>
    readonly timeFormat: UnwrapRef<typeof import('./src/helpers/global.js')['timeFormat']>
    readonly toRaw: UnwrapRef<typeof import('vue')['toRaw']>
    readonly toRef: UnwrapRef<typeof import('vue')['toRef']>
    readonly toRefs: UnwrapRef<typeof import('vue')['toRefs']>
    readonly toValue: UnwrapRef<typeof import('vue')['toValue']>
    readonly triggerRef: UnwrapRef<typeof import('vue')['triggerRef']>
    readonly unref: UnwrapRef<typeof import('vue')['unref']>
    readonly usPhoneFormat: UnwrapRef<typeof import('./src/helpers/global.js')['usPhoneFormat']>
    readonly usStatesList: UnwrapRef<typeof import('./src/helpers/usStates.js')['usStatesList']>
    readonly useAccountsStore: UnwrapRef<typeof import('./src/stores/AccountsStore.js')['useAccountsStore']>
    readonly useAppStore: UnwrapRef<typeof import('./src/stores/AppStore.js')['useAppStore']>
    readonly useAttrs: UnwrapRef<typeof import('vue')['useAttrs']>
    readonly useAuthStore: UnwrapRef<typeof import('./src/stores/AuthStore.js')['useAuthStore']>
    readonly useClipboard: UnwrapRef<typeof import('@vueuse/core')['useClipboard']>
    readonly useCssModule: UnwrapRef<typeof import('vue')['useCssModule']>
    readonly useCssVars: UnwrapRef<typeof import('vue')['useCssVars']>
    readonly useDebounceFn: UnwrapRef<typeof import('@vueuse/core')['useDebounceFn']>
    readonly useImagesStore: UnwrapRef<typeof import('./src/stores/ImagesStore.js')['useImagesStore']>
    readonly useLocalStorage: UnwrapRef<typeof import('@vueuse/core')['useLocalStorage']>
    readonly useMessageStore: UnwrapRef<typeof import('./src/stores/messageStore.js')['useMessageStore']>
    readonly useRoute: UnwrapRef<typeof import('vue-router/auto')['useRoute']>
    readonly useRouter: UnwrapRef<typeof import('vue-router/auto')['useRouter']>
    readonly useSlots: UnwrapRef<typeof import('vue')['useSlots']>
    readonly useUsersStore: UnwrapRef<typeof import('./src/stores/UsersStore.js')['useUsersStore']>
    readonly useVuelidate: UnwrapRef<typeof import('@vuelidate/core')['useVuelidate']>
    readonly useWindowSize: UnwrapRef<typeof import('@vueuse/core')['useWindowSize']>
    readonly userValidator: UnwrapRef<typeof import('./src/helpers/validators.js')['userValidator']>
    readonly watch: UnwrapRef<typeof import('vue')['watch']>
    readonly watchEffect: UnwrapRef<typeof import('vue')['watchEffect']>
    readonly watchPostEffect: UnwrapRef<typeof import('vue')['watchPostEffect']>
    readonly watchSyncEffect: UnwrapRef<typeof import('vue')['watchSyncEffect']>
  }
}
