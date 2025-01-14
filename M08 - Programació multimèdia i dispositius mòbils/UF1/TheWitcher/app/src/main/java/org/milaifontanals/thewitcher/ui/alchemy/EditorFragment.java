package org.milaifontanals.thewitcher.ui.alchemy;

import android.content.pm.ActivityInfo;
import android.os.Bundle;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.ViewModelProvider;

import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;

import org.milaifontanals.thewitcher.R;
import org.milaifontanals.thewitcher.adapters.EditorIngredientsAdapter;
import org.milaifontanals.thewitcher.adapters.EditorSelIngredientsAdapter;
import org.milaifontanals.thewitcher.databinding.FragmentEditorBinding;
import org.milaifontanals.thewitcher.model.Artifact;
import org.milaifontanals.thewitcher.model.Ingredient;
import org.milaifontanals.thewitcher.viewmodel.EditorViewModel;

import java.util.ArrayList;
import java.util.List;

public class EditorFragment extends Fragment implements EditorIngredientsAdapter.IngredientAdapterListener, EditorSelIngredientsAdapter.SelIngredientAdapterListener {

    private EditorViewModel editorViewModel;
    private EditorIngredientsAdapter editorIngredientsAdapter;
    private EditorSelIngredientsAdapter editorSelIngredientsAdapter;
    private FragmentEditorBinding binding;

    private static final String ARG_PARAM1 = "param1";
    private int mParam1;

    private Artifact artifact;

    public EditorFragment() {
    }

    public static EditorFragment newInstance(int param1) {
        EditorFragment fragment = new EditorFragment();
        Bundle args = new Bundle();
        args.putInt(ARG_PARAM1, param1);
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        if (getArguments() != null) {
            mParam1 = getArguments().getInt(ARG_PARAM1);
        }

        editorViewModel=new ViewModelProvider(getActivity()).get(EditorViewModel.class);
        editorViewModel.getArtifactById(mParam1);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        binding= FragmentEditorBinding.inflate(inflater,container,false);
        return binding.getRoot();
    }

    @Override
    public void onViewCreated(@NonNull View view, @Nullable Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        List<Integer> listNum=new ArrayList<>();
        for (int i = 1; i <= 10; i++) {
            listNum.add(i);
        }

        ArrayAdapter<Integer> adapter = new ArrayAdapter<>(requireContext(), R.layout.spinner_layout, listNum);
        binding.spnCharges.setAdapter(adapter);
        binding.spnDuration.setAdapter(adapter);
        binding.txtReturn.setOnClickListener(view1 -> {
            saveArtifact();
            requireActivity().setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE);
            getParentFragmentManager().beginTransaction()
                    .setCustomAnimations(
                            android.R.anim.slide_in_left,
                            android.R.anim.slide_out_right,
                            android.R.anim.slide_in_left,
                            android.R.anim.slide_out_right
                    )
                    .replace(R.id.container,ArtifactFragment.newInstance())
                    .addToBackStack(null)
                    .commit();
        });

        editorViewModel.getArtifact().observe(getViewLifecycleOwner(),artifact1 -> {
            if(artifact1!=null){
                binding.txtName.setText(artifact1.name);
                binding.txtDesc.setText(artifact1.effect);
                binding.spnCharges.setSelection(artifact1.charges-1);
                binding.spnDuration.setSelection(artifact1.duration-1);
                binding.sliFire.setValue(artifact1.fire_damage);
                binding.sliSilver.setValue(artifact1.silver_damage);
                binding.sliPhysical.setValue(artifact1.phy_damage);
                int drawableID=getContext().getResources().getIdentifier(artifact1.image,"drawable",getContext().getPackageName());
                binding.imvPhoto.setImageResource(drawableID);
            }
        });

        editorIngredientsAdapter=new EditorIngredientsAdapter(getContext(),editorViewModel.getIngredients().getValue(),this);
        binding.rcyIngredients.setAdapter(editorIngredientsAdapter);
    }

    private void saveArtifact() {
        artifact=editorViewModel.getArtifact().getValue();
        if(artifact!=null){
            artifact.charges=(Integer)binding.spnCharges.getSelectedItem();
            artifact.duration=(Integer)binding.spnDuration.getSelectedItem();
            artifact.fire_damage= (int) binding.sliFire.getValue();
            artifact.silver_damage= (int) binding.sliSilver.getValue();
            artifact.phy_damage= (int) binding.sliPhysical.getValue();

            editorViewModel.updateArtifact(artifact);
        }
    }

    @Override
    public void onIngredientSelected(Ingredient ingredient) {

    }

    @Override
    public void onSelIngredientSelected(Ingredient ingredient) {

    }
}