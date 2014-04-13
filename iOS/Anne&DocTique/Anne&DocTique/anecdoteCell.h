//
//  anecdoteCell.h
//  Anne&DocTique
//
//  Created by Kapi on 13/04/2014.
//  Copyright (c) 2014 Kapi. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface anecdoteCell : UITableViewCell

@property (weak, nonatomic) IBOutlet UILabel *author;
@property (weak, nonatomic) IBOutlet UILabel *date;
@property (weak, nonatomic) IBOutlet UILabel *descriptionLabel;
@property (weak, nonatomic) IBOutlet UILabel *voteplus;
@property (weak, nonatomic) IBOutlet UILabel *votemoins;
@property (weak, nonatomic) IBOutlet UILabel *favorite;

@end
