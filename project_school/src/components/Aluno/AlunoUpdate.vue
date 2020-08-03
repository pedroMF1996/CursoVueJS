<template>
    <div v-if="!loading">
        <titulo :text="`Atualizar aluno: ${aluno.nome}`" :btnVoltar="!editar">
                <button @click="setEditar()" class="btn btn-editar" v-show="editar">Editar</button>
        </titulo>
    <table>
        <tbody>
            <tr>
                <td class="colPequeno">Matrícula: </td>
                <td><label>{{aluno.id}}</label> </td>
            </tr>
            <tr>
                <td class="colPequeno">Nome: </td>
                <td>
                    <label v-if="editar">{{aluno.nome}}</label>
                    <div v-else>
                        <input type="text" v-model="aluno.nome">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="colPequeno">Sobrenome: </td>
                <td>
                    <label v-if="editar">{{aluno.sobrenome}}</label>
                    <div v-else>
                        <input type="text" v-model="aluno.sobrenome">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="colPequeno">Data de nascimento: </td>
                <td>
                    <label v-if="editar">{{aluno.dataNasc}}</label>
                    <div v-else>
                        <input type="text" v-model="aluno.dataNasc">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="colPequeno">Professor: </td>
                <td>
                    <label v-if="editar">{{aluno.professor.nome}}</label>
                    <div v-else>
                        <select v-model="aluno.professor.id">
                            <option 
                                v-for="(professor, index) in professores" 
                                :key="index" v-bind:value="professor.id"> 
                                {{professor.nome}}
                            </option>
                        </select>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>


    <div style="margin-top:10px;">
        <div v-if="!editar">
            <button @click="salvar(aluno)" class="btn btnSalvar">Salvar</button>
            <button @click="cancelar()" class="btn btnCancelar">Cancelar</button>
        </div>
    </div>
    </div>
</template>

<script>
    import titulo from '../_share/Titulo'
    export default {
        components: {
            titulo,
        },
        props: {
            
        },
        data() {
            return {
                aluno: {},
                professores: [],
                alunoId: this.$route.params.aluno_id,
                editar: true,
                loading: true
            }
        },
        created(){
            this.carregarProfessor();
        },
        methods: {
            setEditar(){
                this.editar = !this.editar;
            },
            salvar(_aluno){
                const _alunoEditar = {
                    id:_aluno.id,
                    nome:_aluno.nome,
                    sobrenome:_aluno.sobrenome,
                    dataNasc:_aluno.dataNasc,
                    professorId:_aluno.professor.id,
                }
                this.$http.put(`http://localhost:5000/api/aluno/${_alunoEditar.id}`, _alunoEditar)
                .then( res => res.json())
                .then(aluno => this.aluno = aluno);
            },
            carregarAluno(){
                this.$http.get("http://localhost:5000/api/aluno/"+this.alunoId)
                .then(res => res.json())
                .then(aluno => {
                    this.aluno = aluno;
                    this.loading = false;
                })
                .then(this.setEditar());
            },
            carregarProfessor(){
                this.$http.get("http://localhost:5000/api/professor")
                .then(res => res.json())
                .then(professores => {
                    this.professores = professores;
                    this.carregarAluno();
                });
            },
            cancelar(){
                this.setEditar()
            }
        },
    }
</script>

<style scoped>
    .colPequeno {
        width: 20%;
    }
    input, select {
        margin: 0px;
        padding: 5px 10px;
        font-size: 0.9 em;
        border: 1px solid silver;
        border-radius: 5px; 
        font-family: Montserrat;
        width: 95%;
        background-color: rgb(245, 245, 245);
    }
    select {
        height: 38px;
        width: 100%;
    }
    .btn-editar{
        float: right;
        background-color: rgb(76, 186, 249);
    }
    .btnSalvar{
        float: right;
        background-color: rgb(79, 196, 68);
    }
    .btnCancelar{
        float: left;
        background-color: rgb(249, 186,42);
    }
    
</style>