import Vue from 'vue';
import Router from 'vue-router'
import Alunos from './components/Aluno/Alunos'
import AlunoUpdate from './components/Aluno/AlunoUpdate'
import Professor from './components/Professor/Professor'
import Sobre from './components/Sobre/Sobre';



Vue.use(Router);

export default new Router(
    {
        routes: [
            {
                name: 'Professores',
                path: '/professores',
                component: Professor
            },
            {
                name: 'Alunos',
                path: '/alunos/:prof_id?',
                component: Alunos
            },
            {
                name: 'AlunosUpdate',
                path: '/aluno/update/:aluno_id',
                component: AlunoUpdate
            },
            {
                name: 'Sobre',
                path: '/sobre',
                component: Sobre
            }
        ]
    }
);