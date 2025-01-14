package org.rockyrk.mtgcards.adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;

import org.rockyrk.mtgcards.R;
import org.rockyrk.mtgcards.model.Card;

import java.util.List;

public class CardAdapter extends RecyclerView.Adapter<CardAdapter.ViewHolder> {

    private List<Card> cards;
    private Context context;

    public CardAdapter(List<Card> cards, Context c) {
        this.cards = cards;
        this.context = c;
    }

    @NonNull
    @Override
    public CardAdapter.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view  =LayoutInflater.from(parent.getContext()).inflate(R.layout.card, parent, false);
        ViewHolder vh = new ViewHolder(view);
        return vh;
    }

    @Override
    public void onBindViewHolder(@NonNull CardAdapter.ViewHolder holder, int position) {
        Card c = cards.get(position);
        holder.txtCardName.setText(c.getName());
        holder.txtCardType.setText(c.getType());
        holder.txtCardDescription.setText(c.getOriginalText());
        if (c.getImageUrl() != null) {
            Glide.with(context).load(c.getImageUrl()).into(holder.imgCardImage);
        }
    }

    @Override
    public int getItemCount() {
        return cards.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {

        private ImageView imgCardImage;
        private TextView txtCardName;
        private TextView txtCardType;
        private TextView txtCardDescription;
        public ViewHolder(@NonNull View itemView) {
            super(itemView);
            imgCardImage = itemView.findViewById(R.id.imgCardImage);
            txtCardName = itemView.findViewById(R.id.txtCardName);
            txtCardType = itemView.findViewById(R.id.txtCardType);
            txtCardDescription = itemView.findViewById(R.id.txtCardDescription);
        }
    }
}
