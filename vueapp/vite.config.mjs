
import { fileURLToPath, URL }   from 'node:url'
import { defineConfig }         from 'vite'
import mkcert                   from 'vite-plugin-mkcert'
import vue                      from '@vitejs/plugin-vue'
import VueRouter                from 'unplugin-vue-router/vite'
import AutoImport               from 'unplugin-auto-import/vite'
import Components               from 'unplugin-vue-components/vite'
import { VueRouterAutoImports } from 'unplugin-vue-router'

export default defineConfig({
    plugins: 
    [
        AutoImport({
            dts: true,
            vueTemplate: true,
            dirs: ['./src/helpers', './src/models', './src/stores'],
            imports: [
                'vue',
                VueRouterAutoImports,
                { 
                    '@vueuse/core': 
                    [
                        'useClipboard',
                        'useDebounceFn',
                        'useLocalStorage',
                        'useWindowSize',
                        ['useDraggable' , 'Draggable']
                    ],
                    'pinia': 
                    [
                        'storeToRefs',
                        'defineStore'
                    ],
                    '@vuelidate/core': 
                    [
                        'useVuelidate'
                    ]
                }	
            ],	
            eslintrc: {
                enabled: true
            }
        }),
        VueRouter({
            dts: true
        }),        
        vue(),
        mkcert(),
        Components({
            dirs: ['./src/components', './src/layouts'],
            dts: true
        })
    ],
    resolve: {
        alias: {
            '@': fileURLToPath(new URL('./src', import.meta.url))
        }
    },
    server: {
        proxy: {
            '^/weatherforecast': {
                target: 'https://localhost:7199/', 
                secure: false
            }
        },
        port: 7200,
        open: true  // open the browser after compiling
    }
 
})
